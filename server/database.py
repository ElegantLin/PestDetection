#encoding=utf-8
import pymysql,json
from datetime import datetime
import util
import random, string

def get_connect():
    db = pymysql.connect(host="111.198.4.119", port=3336, user="root", password="x745DzjBackend", database="dzjDB", charset='utf8')
    return db

def close_connect(db):
    db.close()

def login(user_name, pwd, mac_address):
    db = get_connect()
    cursor = db.cursor()
    find_user = "SELECT * FROM user WHERE user_name = {};".format(repr(user_name))
    try:
        cursor.execute(find_user)
        results = cursor.fetchall()
        if len(results) == 0:
            return 0, -1
        if results[0][2] == pwd:
            if results[0][15] == mac_address:
                return 1, results[0][3]
            else:
                return 3, -1
        else:
            return 2, -1
    except Exception as e:
        print(e)

def store(date, path, res):
    db = get_connect()
    cursor = db.cursor()
    store_identify = "INSERT INTO identify(path, datetime, res) VALUES ({},{},{});".\
        format(repr(path),repr(date),repr(res))
    try:
        cursor.execute(store_identify)
        db.commit()
        return 1
    except Exception as e:
        db.rollback()
        print(e)
        return 0

def search_history(date):
    db = get_connect()
    cursor = db.cursor()
    date_object = datetime.strptime(date, '%Y/%m/%d')
    date_str = date_object.strftime('%Y-%m-%d')
    find_history = "SELECT * FROM identify WHERE datetime = {};".format(repr(date_str))
    try:
        cursor.execute(find_history)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def search_files(file_type, type, level2, level3, level4):
    db = get_connect()
    cursor = db.cursor()
    find_info = ""
    if level2 is None:
        find_info = "SELECT * FROM pdf_file WHERE file_class = {};".format(repr(type))
    elif level3 is None:
        level2 = int(level2)
        find_info = "SELECT * FROM pdf_file WHERE file_class = {} AND level2={};".format(repr(type), repr(level2))
    elif level4 is None:
        level2 = int(level2)
        level3 = int(level3)
        find_info = "SELECT * FROM pdf_file WHERE file_class = {} AND level2={} AND level3={};".format(repr(type), repr(level2), repr(level3))
    else:
        level2 = int(level2)
        level3 = int(level3)
        level4 = int(level4)
        find_info = "SELECT * FROM pdf_file WHERE file_class = {} AND level2={} AND level3={} AND level4={};".format(repr(type),repr(level2),repr(level3),repr(level4))
    if file_type is not None:
        find_info = find_info[:-1] + " AND file_type={};".format(repr(file_type))
    try:
        cursor.execute(find_info)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def search_files_with_details(file_type, type, start_date, end_date, keyword):
    db = get_connect()
    cursor = db.cursor()
    find_info = ""
    if start_date is None and keyword is None:
        find_info = "SELECT * FROM pdf_file WHERE;"
    elif start_date is None:
        keyword = '%' + keyword + '%'
        find_info = "SELECT * FROM pdf_file WHERE file_title like {};".format(repr(keyword))
    elif keyword is None:
        find_info = "SELECT * FROM pdf_file WHERE \
        file_time >= {} AND file_time <= {};".format(repr(start_date), repr(end_date))
    else:
        keyword = '%' + keyword + '%'
        find_info = "SELECT * FROM pdf_file WHERE \
        file_time >= {} AND file_time <= {} AND file_title like {};".format(repr(start_date), repr(end_date), repr(keyword))
    if type is not None:
        find_info = find_info[:-1] + " AND file_class={};".format(repr(type))
    if file_type is not None:
        find_info = find_info[:-1] + " AND file_type={};".format(repr(file_type))
    try:
        cursor.execute(find_info)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def store_declares(user, num, type, country, remark, images, way, department, date_str, cargo, position, status, res):
    db = get_connect()
    cursor = db.cursor()
    images_urls = ""
    for img in images:
        images_urls += img
        images_urls += "~"
    images_urls = images_urls[:-1]
    print(images_urls)
    search_user = "SELECT user_id FROM user WHERE user_name={};".format(repr(user))
    try:
        cursor.execute(search_user)
        user_id = cursor.fetchall()[0][0]
        store_identify = "INSERT INTO declare_table(user_id, declare_num, declare_type, declare_country, declare_remark,\
        declare_imgs, declare_way, declare_department, declare_date, declare_cargo, declare_position, status, res_num, eval_date) VALUES (\
        {},{},{},{},{},{},{},{},{},{},{},{},{},now());".format(repr(user_id), repr(num), repr(type), repr(country), repr(remark),\
        repr(images_urls), repr(way), repr(department), repr(date_str), repr(cargo), repr(position), repr(status), repr(res))
        cursor.execute(store_identify)
        db.commit()
        return 1
    except Exception as e:
        db.rollback()
        print(e)
        return 0

def get_declare_records(user, way):
    db = get_connect()
    cursor = db.cursor()
    search_user = "SELECT user_id FROM user WHERE user_name={};".format(repr(user))
    try:
        cursor.execute(search_user)
        user_id = cursor.fetchall()[0][0]
        find_info = ""
        if way is None:
            find_info = "SELECT * FROM declare_table WHERE user_id = {};".format(repr(user_id))
        else:
            find_info = "SELECT * FROM declare_table WHERE user_id = {} AND declare_way = {};".format(repr(user_id), repr(int(way)))
        cursor.execute(find_info)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def search_declare_with_details(user, way, start_date, end_date, keyword, state):
    types = ["昆虫", "杂草"]
    ways = ["离线鉴定", "在线鉴定"]
    db = get_connect()
    cursor = db.cursor()
    search_user = "SELECT user_id FROM user WHERE user_name={};".format(repr(user))
    try:
        cursor.execute(search_user)
        user_id = cursor.fetchall()[0][0]
        if keyword is not None:
            type_index = -1
            way_index = -1
            user_index = -1
            if keyword in types:
                type_index = types.index(keyword)
            if keyword in ways:
                way_index = ways.index(keyword)
            if keyword == user:
                user_index = int(user_id)
        find_info = ""
        if way is None:
            if start_date is None and keyword is None:
                find_info = "SELECT * FROM declare_table WHERE user_id = {};".format(repr(user_id))
            elif start_date is None:
                keyword = '%' + keyword + '%'
                find_info = "SELECT * FROM declare_table WHERE user_id = {} \
                                AND (declare_num like {} OR declare_country like {} OR declare_department like {} \
                                declare_cargo like {} OR declare_position like {});".format(repr(user_id), \
                    repr(keyword), repr(keyword), repr(keyword), repr(keyword), repr(keyword))
                if type_index != -1:
                    find_info = find_info[:-2] + " OR declare_type={});".format(type_index)
                elif way_index != -1:
                    find_info = find_info[:-2] + " OR declare_way={});".format(way_index)
                elif user_index != -1:
                    find_info = find_info[:-2] + " OR user_id ={});".format(user_index)
            elif keyword is None:
                find_info = "SELECT * FROM declare_table WHERE user_id = {} AND \
                declare_date >= {} AND declare_date <= {};".format(repr(user_id), repr(start_date), repr(end_date))
            else:
                keyword = '%' + keyword + '%'
                find_info = "SELECT * FROM declare_table WHERE user_id = {} AND declare_date >= {} AND declare_date <= {} \
                AND (declare_num like {} OR declare_country like {} OR declare_department like {} \
                OR declare_cargo like {} OR declare_position like {});".format(repr(user_id), repr(start_date), repr(end_date), \
                repr(keyword), repr(keyword), repr(keyword), repr(keyword), repr(keyword))
                if type_index != -1:
                    find_info = find_info[:-2] + " OR declare_type={});".format(type_index)
                elif way_index != -1:
                    find_info = find_info[:-2] + " OR declare_way={});".format(way_index)
                elif user_index != -1:
                    find_info = find_info[:-2] + " OR user_id ={});".format(user_index)
        else:
            if start_date is None and keyword is None:
                find_info = "SELECT * FROM declare_table WHERE user_id = {} AND declare_way = {};".format(repr(user_id), repr(int(way)))
            elif start_date is None:
                keyword = '%' + keyword + '%'
                find_info = "SELECT * FROM declare_table WHERE user_id = {} AND declare_way = {} \
                 AND (declare_num like {} OR declare_country like {} OR declare_department like {} \
                declare_cargo like {} OR declare_position like {});".format(repr(user_id), repr(int(way)),\
                repr(keyword), repr(keyword), repr(keyword), repr(keyword), repr(keyword))
                if type_index != -1:
                    find_info = find_info[:-2] + " OR declare_type={});".format(type_index)
                elif way_index != -1:
                    find_info = find_info[:-2] + " OR declare_way={});".format(way_index)
                elif user_index != -1:
                    find_info = find_info[:-2] + " OR user_id ={});".format(user_index)
            elif keyword is None:
                find_info = "SELECT * FROM declare_table WHERE user_id = {} AND declare_way = {} AND\
                declare_date >= {} AND declare_date <= {};".format(repr(user_id), repr(int(way)), repr(start_date), repr(end_date))
            else:
                keyword = '%' + keyword + '%'
                find_info = "SELECT * FROM declare_table WHERE user_id = {} AND declare_way = {} AND\
                declare_date >= {} AND declare_date <= {} \
                AND (declare_num like {} OR declare_country like {} OR declare_department like {} \
                OR declare_cargo like {} OR declare_position like {});".format(repr(user_id), repr(int(way)), repr(start_date), repr(end_date), \
                repr(keyword), repr(keyword), repr(keyword), repr(keyword), repr(keyword))
                if type_index != -1:
                    find_info = find_info[:-2] + " OR declare_type={});".format(type_index)
                elif way_index != -1:
                    find_info = find_info[:-2] + " OR declare_way={});".format(way_index)
                elif user_index != -1:
                    find_info = find_info[:-2] + " OR user_id ={});".format(user_index)
        if state is not None:
            find_info = find_info[:-1] + " AND status={}".format(repr(state))
        cursor.execute(find_info)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def search_user(user):
    db = get_connect()
    cursor = db.cursor()
    find_user = "SELECT * FROM user WHERE user_name={};".format(repr(user))
    try:
        cursor.execute(find_user)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def update_acc(user, oripwd, curpwd, type, name, department, region, year, title):
    db = get_connect()
    cursor = db.cursor()
    find_user = "SELECT * FROM user WHERE user_name={};".format(repr(user))
    try:
        cursor.execute(find_user)
        results = cursor.fetchall()
        user_id = int(results[0][0])
        pwd = results[0][2]
        update_sql = ""
        if oripwd != "":
            if oripwd != pwd:
                return 0
            elif curpwd != "":
                update_sql = "UPDATE user SET pwd={}, user_type={}, name={}, department={}, region={}, work_year={}, user_title={}\
                WHERE user_id={};".format(repr(curpwd), repr(type), repr(name), repr(department), repr(region), repr(year), repr(title), repr(user_id))
        else:
            update_sql = "UPDATE user SET user_type={}, name={}, department={}, region={}, work_year={}, user_title={} WHERE user_id={};" \
                .format(repr(type), repr(name), repr(department), repr(region), repr(year), repr(title), repr(user_id))
        cursor.execute(update_sql)
        db.commit()
        return 1
    except Exception as e:
        print(e)
        db.rollback()
        return 2

def search_allusers(type, keyword):
    db = get_connect()
    cursor = db.cursor()
    find_user = ""
    if keyword is None and type is None:
        find_user = "SELECT * FROM user;"
    elif keyword is None:
        find_user = "SELECT * FROM user WHERE user_type = {};".format(repr(type))
    elif type is None:
        keyword = '%' + keyword + '%'
        find_user = "SELECT * FROM user WHERE user_name like {} OR user_type like {} OR \
                name like {} OR department like {} OR region like {} OR work_year like {} OR \
                user_title like {};".format(repr(keyword), repr(keyword), repr(keyword), repr(keyword), \
                                            repr(keyword), repr(keyword), repr(keyword))
    else:
        keyword = '%' + keyword + '%'
        find_user = "SELECT * FROM user WHERE user_type={} AND (user_name like {} OR user_type like {} OR \
        name like {} OR department like {} OR region like {} OR work_year like {} OR \
        user_title like {});".format(repr(type), repr(keyword), repr(keyword), repr(keyword), repr(keyword),\
        repr(keyword), repr(keyword), repr(keyword))
    try:
        cursor.execute(find_user)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def store_file(today, filename, title, file_type, level1, level2, level3, level4, owner):
    db = get_connect()
    cursor = db.cursor()
    try:
        find_title = "SELECT * FROM pdf_file WHERE file_title={};".format(repr(title))
        cursor.execute(find_title)
        results = cursor.fetchall()
        if len(results) > 0:
            return -1
        find_name = "SELECT * FROM pdf_file WHERE file_url={} AND file_type={} AND level1={};".format(repr(filename), repr(file_type), repr(int(level1)))
        if level2 is not None:
            find_name = find_name[:-1] + " AND level2={};".format(repr(int(level2)))
        if level3 is not None:
            find_name = find_name[:-1] + " AND level3={};".format(repr(int(level3)))
        if level4 is not None:
            find_name = find_name[:-1] + " AND level4={};".format(repr(int(level4)))
        cursor.execute(find_name)
        results = cursor.fetchall()
        if len(results) > 0:
            return -2
        find_user = "SELECT * FROM user WHERE user_name={};".format(repr(owner))
        cursor.execute(find_user)
        results = cursor.fetchall()
        user_id = results[0][0]
        save_file = ""
        if level2 is None:
            save_file = "INSERT INTO pdf_file(file_title, file_time, file_url, file_type, file_class, level1, owner_id\
            ) VALUES ({}, {}, {}, {}, {}, {}, {})".format(repr(title), repr(today), repr(filename), \
            repr(file_type), repr(int(level1)), repr(level1), repr(user_id))
        elif level3 is None:
            level2 = int(level2)
            save_file = "INSERT INTO pdf_file(file_title, file_time, file_url, file_type, file_class, level1, level2, owner_id\
            ) VALUES ({}, {}, {}, {}, {}, {}, {}, {})".format(repr(title), repr(today), repr(filename), \
            repr(file_type), repr(int(level1)), repr(level1), repr(level2),repr(user_id))
        elif level4 is None:
            level2 = int(level2)
            level3 = int(level3)
            save_file = "INSERT INTO pdf_file(file_title, file_time, file_url, file_type, file_class, level1, level2, level3, owner_id\
            ) VALUES ({}, {}, {}, {}, {}, {}, {}, {}, {})".format(repr(title), repr(today), repr(filename), \
            repr(file_type), repr(level1), repr(int(level1)), repr(level2), repr(level3), repr(user_id))
        else:
            level2 = int(level2)
            level3 = int(level3)
            level4 = int(level4)
            save_file = "INSERT INTO pdf_file(file_title, file_time, file_url, file_type, file_class, level1, level2, level3, level4, owner_id\
            ) VALUES ({}, {}, {}, {}, {}, {}, {}, {}, {}, {})".format(repr(title), repr(today), repr(filename), \
            repr(file_type), repr(level1), repr(int(level1)), repr(level2), repr(level3), repr(level4), repr(user_id))
        cursor.execute(save_file)
        db.commit()
        return 1
    except Exception as e:
        print(e)
        return 0

def get_user_type():
    db = get_connect()
    cursor = db.cursor()
    find_type = "SELECT DISTINCT(user_type) FROM user;"
    try:
        cursor.execute(find_type)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def delete_file(url):
    db = get_connect()
    cursor = db.cursor()
    file_url = "DELETE FROM pdf_file WHERE file_url = {};".format(repr(url))
    try:
        cursor.execute(file_url)
        db.commit()
        return 1
    except Exception as e:
        db.rollback()
        print(e)
        return 0

def find_sample_type(sample_num):
    db = get_connect()
    cursor = db.cursor()
    find_sample = "SELECT * FROM sample_table WHERE number={};".format(repr(sample_num))
    try:
        cursor.execute(find_sample)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def register(name, pwd, email, auth_code, mac_address):
    db = get_connect()
    cursor = db.cursor()
    find_user = "SELECT * FROM user WHERE user_name={};".format(repr(name))
    try:
        cursor.execute(find_user)
        results = cursor.fetchall()
        if len(results) > 0:
            return -1
        find_code = "SELECT * FROM user WHERE auth_code={};".format(repr(auth_code))
        cursor.execute(find_code)
        results = cursor.fetchall()
        if len(results) > 0:
            return 2
        find_codes = "SELECT * FROM auth_code WHERE code={};".format(repr(auth_code))
        cursor.execute(find_codes)
        results = cursor.fetchall()
        if len(results) == 0:
            return 3
        register_url = "INSERT INTO user(user_name, pwd, authority, email, auth_code, mac_address) VALUES(" \
                       "{}, {}, {}, {}, {}, {})".format(repr(name), repr(pwd), repr(0), repr(email), repr(auth_code), repr(mac_address))
        cursor.execute(register_url)
        db.commit()
        return 1
    except Exception as e:
        db.rollback()
        print(e)
        return 0

def send_reset(user):
    db = get_connect()
    cursor = db.cursor()
    find_email = "SELECT * FROM user WHERE user_name={};".format(repr(user))
    try:
        cursor.execute(find_email)
        results = cursor.fetchall()
        if len(results) == 0:
            return 0
        user_id = results[0][0]
        email = results[0][10]
        if email is None:
            return -1
        res, pwd_str = util.send_to_user(user, email)
        if res:
            reset_sql = "UPDATE user SET pwd={} WHERE user_id={};".format(repr(pwd_str), repr(user_id))
            try:
                cursor.execute(reset_sql)
                db.commit()
                return 1
            except Exception as e:
                db.rollback()
                return 2
        else:
            return 2
    except Exception as e:
        db.rollback()
        print(e)
        return 2

def update_multi(index, value):
    db = get_connect()
    cursor = db.cursor()
    col = ['user_name', 'pwd', 'user_type', 'name', 'department', 'region', 'work_year', 'user_title', 'authority']
    indexes_first = index.split("+")
    values_first = value.split("+")
    tag = 1
    for i in range(len(indexes_first)):
        info = indexes_first[i].split("<")
        user, count = info[0], info[1]
        data = values_first[i].split("<")
        detail = data[1]
        count_index = count.split(",")
        detail_value = detail.split(",")
        sql_text = "UPDATE user SET "
        for j in range(len(count_index)):
            sql_text += col[int(count_index[j])]
            sql_text += "="
            if col[int(count_index[j])] == 'authority':
                sql_text += '0' if detail_value[j] == '普通' else '1'
            elif col[int(count_index[j])] != 'work_year':
                sql_text += "\'" + detail_value[j] +  "\'"
            else:
                sql_text += detail_value[j]
            if j != len(count_index) - 1:
                sql_text += ", "
        sql_text = sql_text + " WHERE user_name=" + "\'" + user +  "\';"
        print(sql_text)
        try:
            cursor.execute(sql_text)
            db.commit()
        except Exception as e:
            db.rollback()
            print(e)
            tag = 0
    return tag

def find_platform(start_str, end_str, keyword):
    db = get_connect()
    cursor = db.cursor()
    find_platform = "SELECT * FROM platform;"
    if start_str is None:
        if keyword is not None:
            keyword = '%' + keyword + '%'
            find_platform = "SELECT * FROM platform WHERE title like {};".format(repr(keyword))
    else:
        if keyword is None:
            find_platform = "SELECT * FROM platform WHERE date >= {} AND date <= {};".format(repr(start_str), repr(end_str))
        else:
            keyword = '%' + keyword + '%'
            find_platform = "SELECT * FROM platform WHERE title like {} AND date >= {} AND date <= {};".format(repr(keyword), repr(start_str), repr(end_str))
    try:
        cursor.execute(find_platform)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def store_platform(today, title, owner):
    db = get_connect()
    cursor = db.cursor()
    find_user = "SELECT * FROM user WHERE user_name={};".format(repr(owner))
    try:
        cursor.execute(find_user)
        results = cursor.fetchall()
        if len(results) == 0:
            return -1
        user_id = results[0][0]
        upload_url = "INSERT INTO platform(title, date, user_id) VALUES({}, {}, {})".format(repr(title), repr(today), repr(user_id))
        print(upload_url)
        cursor.execute(upload_url)
        db.commit()
        return 1
    except Exception as e:
        db.rollback()
        print(e)
        return 0

def delete_platform(title):
    db = get_connect()
    cursor = db.cursor()
    delete_sql = "DELETE FROM platform WHERE title={};".format(repr(title))
    try:
        cursor.execute(delete_sql)
        db.commit()
        return 1
    except Exception as e:
        db.rollback()
        print(e)
        return 0

def declare_info(num):
    db = get_connect()
    cursor = db.cursor()
    find_declare = "SELECT * FROM declare_table WHERE declare_num={};".format(repr(num))
    try:
        cursor.execute(find_declare)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def declare_url(num):
    db = get_connect()
    cursor = db.cursor()
    find_declare = "SELECT * FROM declare_table WHERE declare_num={};".format(repr(num))
    try:
        cursor.execute(find_declare)
        results = cursor.fetchall()
        return results[0][6]
    except Exception as e:
        print(e)

def update_declare(num, type, country, remark, change_img, images_urls, way, department, declare_date, cargo, position, status, res,user_name):
    db = get_connect()
    cursor = db.cursor()
    update_declare = "UPDATE declare_table SET declare_type={}, declare_country={}, declare_remark={}, declare_way={}," \
                     "declare_department={}, declare_date={}, declare_cargo={}, declare_position={}, status={}, res_num={}, expert_id = {}, eval_date = now() "
    if change_img is None or len(change_img) == 0:
        update_declare = (update_declare + " WHERE declare_num={};").format(
            repr(type),
            repr(country),
            repr(remark),
            repr(way),
            repr(department),
            repr(declare_date),
            repr(cargo),
            repr(position),
            repr(status),
            repr(res),
            repr(user_name),
            repr(num)

        )
    else:
        update_declare = (update_declare + ", declare_imgs={} WHERE declare_num={};").format(
            repr(type),
            repr(country),
            repr(remark),
            repr(way),
            repr(department),
            repr(declare_date),
            repr(cargo),
            repr(position),
            repr(status),
            repr(res),
            repr(user_name),
            repr(images_urls),
            repr(num)
        )
    print(update_declare)
    try:
        cursor.execute(update_declare)
        db.commit()
        return 1
    except Exception as e:
        print(e)
        db.rollback()
        return 2

def search_sample(keyword):
    db = get_connect()
    cursor = db.cursor()
    keyword = '%' + keyword + '%'
    find_sample = "SELECT * FROM sample_table WHERE 1 AND CONCAT(" \
                  "IFNULL(phylum_cn, ''), IFNULL(phylum_latin, ''), IFNULL(phylum_num, ''), " \
                  "IFNULL(class_cn, ''), IFNULL(class_latin, ''), IFNULL(class_num, ''), " \
                  "IFNULL(order_cn, ''), IFNULL(order_latin, ''), IFNULL(order_num, ''), " \
                  "IFNULL(family_cn, ''), IFNULL(family_latin, ''), IFNULL(family_num, ''), " \
                  "IFNULL(genus_cn, ''), IFNULL(genus_latin, ''), IFNULL(genus_num, ''), " \
                  "IFNULL(species_cn, ''), IFNULL(species_other, ''), IFNULL(species_latin, ''), IFNULL(species_num, ''), " \
                  "IFNULL(number, '')) like {};".format(repr(keyword))
    try:
        cursor.execute(find_sample)
        results = cursor.fetchall()
        return results
    except Exception as e:
        print(e)

def search_species(page, type, keyword):
    start = int(page) * 8
    num = 8
    db = get_connect()
    cursor = db.cursor()
    find_species = "SELECT * FROM sample_table"
    total_sql = "SELECT count(*) FROM sample_table;"
    if type is None:
        if keyword is None:
            find_species = find_species + " limit {},{};".format(repr(start), repr(num))
        else:
            keyword = '%' + keyword + '%'
            find_species = "SELECT * FROM sample_table WHERE 1 AND CONCAT(" \
            "IFNULL(phylum_cn, ''), IFNULL(phylum_latin, ''), IFNULL(phylum_num, ''), " \
            "IFNULL(class_cn, ''), IFNULL(class_latin, ''), IFNULL(class_num, ''), " \
            "IFNULL(order_cn, ''), IFNULL(order_latin, ''), IFNULL(order_num, ''), " \
            "IFNULL(family_cn, ''), IFNULL(family_latin, ''), IFNULL(family_num, ''), " \
            "IFNULL(genus_cn, ''), IFNULL(genus_latin, ''), IFNULL(genus_num, ''), " \
            "IFNULL(species_cn, ''), IFNULL(species_other, ''), IFNULL(species_latin, ''), IFNULL(species_num, ''), " \
            "IFNULL(number, '')) like {} limit {},{};".format(repr(keyword), repr(start), repr(num))
            total_sql = "SELECT count(*) FROM sample_table WHERE 1 AND CONCAT(" \
            "IFNULL(phylum_cn, ''), IFNULL(phylum_latin, ''), IFNULL(phylum_num, ''), " \
            "IFNULL(class_cn, ''), IFNULL(class_latin, ''), IFNULL(class_num, ''), " \
            "IFNULL(order_cn, ''), IFNULL(order_latin, ''), IFNULL(order_num, ''), " \
            "IFNULL(family_cn, ''), IFNULL(family_latin, ''), IFNULL(family_num, ''), " \
            "IFNULL(genus_cn, ''), IFNULL(genus_latin, ''), IFNULL(genus_num, ''), " \
            "IFNULL(species_cn, ''), IFNULL(species_other, ''), IFNULL(species_latin, ''), IFNULL(species_num, ''), " \
            "IFNULL(number, '')) like {};".format(repr(keyword))
    else:
        if keyword is None:
            find_species = find_species + " WHERE sample_type={} limit {},{};".format(repr(type), repr(start), repr(num))
            total_sql = "SELECT count(*) FROM sample_table WHERE sample_type={};".format(repr(type))
        else:
            keyword = '%' + keyword + '%'
            find_species = "SELECT * FROM sample_table WHERE 1 AND CONCAT(" \
            "IFNULL(phylum_cn, ''), IFNULL(phylum_latin, ''), IFNULL(phylum_num, ''), " \
            "IFNULL(class_cn, ''), IFNULL(class_latin, ''), IFNULL(class_num, ''), " \
            "IFNULL(order_cn, ''), IFNULL(order_latin, ''), IFNULL(order_num, ''), " \
            "IFNULL(family_cn, ''), IFNULL(family_latin, ''), IFNULL(family_num, ''), " \
            "IFNULL(genus_cn, ''), IFNULL(genus_latin, ''), IFNULL(genus_num, ''), " \
            "IFNULL(species_cn, ''), IFNULL(species_other, ''), IFNULL(species_latin, ''), IFNULL(species_num, ''), " \
            "IFNULL(number, '')) like {} AND sample_type={} limit {},{};".format(repr(keyword), repr(type), repr(start), repr(num))
            total_sql = "SELECT count(*) FROM sample_table WHERE 1 AND CONCAT(" \
            "IFNULL(phylum_cn, ''), IFNULL(phylum_latin, ''), IFNULL(phylum_num, ''), " \
            "IFNULL(class_cn, ''), IFNULL(class_latin, ''), IFNULL(class_num, ''), " \
            "IFNULL(order_cn, ''), IFNULL(order_latin, ''), IFNULL(order_num, ''), " \
            "IFNULL(family_cn, ''), IFNULL(family_latin, ''), IFNULL(family_num, ''), " \
            "IFNULL(genus_cn, ''), IFNULL(genus_latin, ''), IFNULL(genus_num, ''), " \
            "IFNULL(species_cn, ''), IFNULL(species_other, ''), IFNULL(species_latin, ''), IFNULL(species_num, ''), " \
            "IFNULL(number, '')) like {} AND sample_type={};".format(repr(keyword), repr(type))
    try:
        cursor.execute(find_species)
        results = cursor.fetchall()
        cursor.execute(total_sql)
        count = cursor.fetchall()
        return results, int(int(count[0][0]) / 8) + 1
    except Exception as e:
        print(e)

def generate_code(size):
    db = get_connect()
    cursor = db.cursor()
    ran_str = ''.join(random.sample(string.ascii_letters + string.digits, 8))
    insert_code = "INSERT INTO auth_code(code) VALUES({});".format(repr(ran_str))
    try:
        cursor.execute(insert_code)
        db.commit()
        return 1, ran_str
    except Exception as e:
        db.rollback()
        print(e)
        return 0, None
