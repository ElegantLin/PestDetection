#encoding=utf-8
from flask import Flask, request
import json
import os
import datatest
import database
import datetime
import base64
import util
import config

app = Flask(__name__, static_folder='./static')
img_path = '/home/x745/backend/data/test/'
store_path = '/home/x745/backend/data/store/'
declare_path = '/home/x745/backend/data/declare/'
pdfs_path = '/home/x745/backend/dzjBackend/static/files/'
pdf_urls = 'http://111.198.4.119:5000/static/files/'
image_path = '/home/x745/backend/dzjBackend/static/data/'
image_url = 'http://111.198.4.119:5000/static/data/'
show_declare_path = '/home/x745/backend/dzjBackend/static/data/sample/'
show_declare_url = 'http://111.198.4.119:5000/static/data/sample/'

@app.route("/")
def hello():
    return "<h1 style='color:blue'>Hello There!</h1>"

# 生成授权码
@app.route('/api/generate_code', methods=['GET'])
def generate_code():
    size = request.args.get('size')
    code, detail = database.generate_code(size)
    if code == 1:
        return json.dumps({'status': 'ok', 'code': detail})
    else:
        return json.dumps({'status': 'error'})

# 获取物种详细信息
@app.route('/api/search_species', methods=['GET'])
def search_species():
    page = request.args.get('page')
    type = request.args.get('type')
    keyword = request.args.get('keyword')
    tmp, size = database.search_species(page, type, keyword)
    res = []
    if tmp:
        for item in tmp:
            quar = "未知"
            isquar = int(item[2])
            if isquar == 0:
                quar = "否"
            elif isquar == 1:
                quar = "是"
            item_type = int(item[1])
            sample_num = item[22]
            sub_path = "grassdataset"
            if int(item_type) == 0:
                sub_path = "insectdataset"
            img_path = image_path + sub_path + '/0' + sample_num + '/'
            img_url = image_url + sub_path + '/0' + sample_num + '/'
            if (os.path.exists(img_path)):
                images = os.listdir(img_path)
                img_url = img_url + images[0]
            temp = {
                "page_count": size, "img_url": img_url, "type": item[1], "final_num": sample_num,
                "species_cn": item[18], "species_latin": item[20], "family_cn": item[12], "family_latin": item[13],
                "isquar": quar
            }
            res.append(temp)
    return json.dumps(res, ensure_ascii=False)

# 获取物种搜索
@app.route('/api/search_sample', methods=['GET'])
def search_sample():
    keyword = request.args.get('keyword')
    tmp = database.search_sample(keyword)
    res = []
    if tmp:
        for item in tmp:
            temp = {
                "num": item[22], "species_cn": item[18], "type": item[1]
            }
            res.append(temp)
    return json.dumps(res, ensure_ascii=False)

# 更新申报信息
@app.route('/api/update_declare', methods=['POST'])
def update_declare():
    tag = 0
    num = request.form.get('num')
    type = request.form.get('type')
    country = request.form.get('country')
    remark = request.form.get('remark')
    change_img = request.form.get('change_img')
    files = request.files.getlist('file')
    way = request.form.get('way')
    department = request.form.get('department')
    declare_date = request.form.get('date')
    cargo = request.form.get('cargo')
    position = request.form.get('pos')
    status = request.form.get('status')
    res = request.form.get('res')
    img_url = request.form.get('img_url')
    user_name = request.form.get('user_name')
    if num is None:
        tag = 1
        num = request.args.get('num')
        type = request.args.get('type')
        country = request.args.get('country')
        remark = request.args.get('remark')
        change_img = request.args.get('change_img')
        way = request.args.get('way')
        department = request.args.get('department')
        declare_date = request.args.get('date')
        cargo = request.args.get('cargo')
        position = request.args.get('pos')
        status = request.args.get('status')
        res = request.args.get('res')
        img_url = request.args.get('img_url')
        user_name = request.args.get('user_name')
    country = util.to_normal_char(country)
    remark = util.to_normal_char(remark)
    change_img = util.to_normal_char(change_img)
    department = util.to_normal_char(department)
    declare_date = util.to_normal_char(declare_date)
    declare_date = datetime.datetime.strptime(declare_date, '%Y/%m/%d')
    declare_date = declare_date.strftime('%Y-%m-%d')
    cargo = util.to_normal_char(cargo)
    position = util.to_normal_char(position)
    img_url = util.to_normal_char(img_url)
    user_name = util.to_normal_char(user_name)
    if status is None:
        status = 0
    if res is None:
        res = ""
    images_urls = ""
    if change_img is None or len(change_img) == 0:
        if int(way) == 0:
            url = img_url.split('~')[0]
            url = url.replace('http://111.198.4.119:5000/', '/home/x745/backend/dzjBackend/')
            if os.path.exists(url):
                number, objName = datatest.identify(url, int(type))
                if res == "":
                    res = number
                    status = 1
            else:
                return json.dumps({'status': 'update failed'})
    else:
        indexes = [int(x) for x in change_img.split('+')]
        deurl = database.declare_url(num)
        urls = deurl.split('~')
        for i, file in enumerate(files):
            name = str(hash(file.filename.split('.')[0]))
            file_type = file.filename.split('.')[-1]
            filename = declare_path + name + '.' + file_type
            file.save(filename)
            if os.path.exists(filename):
                if indexes[i] == len(urls):
                    urls.append(filename)
                elif indexes[i] == len(urls) + 1:
                    urls.append("")
                    urls.append(filename)
                else:
                    urls[indexes[i]] = filename
        for img in urls:
            images_urls += img
            images_urls += "~"
        images_urls = images_urls[:-1]
        if way == "0":
            url = images_urls.split('~')[0]
            url = url.replace('http://111.198.4.119:5000/', '/home/x745/backend/dzjBackend/')
            if os.path.exists(url):
                number, objName = datatest.identify(url, int(type))
                if res == "":
                    res = number
                    status = 1
            else:
                return json.dumps({'status': 'update failed'})
    code = database.update_declare(num, int(type), country, remark, change_img, images_urls, int(way), department, declare_date,
                                   cargo, position, int(status), res,user_name)
    if code == 1:
        return json.dumps({'status': 'ok'})
    else:
        return json.dumps({'status': 'update failed'})

# 获取鉴定详情
@app.route('/api/declare_info', methods=['GET'])
def declare_info():
    status = ["未鉴定", "已鉴定"]
    num = request.args.get('num')
    tmp = database.declare_info(num)
    res = []
    if tmp:
        for item in tmp:
            urls = []
            paths = item[6].split('~')
            for path in paths:
                name = path.split('/')[-1]
                os.system('cp ' + path + ' ' + show_declare_path)
                urls.append(show_declare_url + name)
            multi = ""
            for url in urls:
                multi += url
                multi += "~"
            multi = multi[:-1]
            temp = {
                "num": item[2], "type": item[3], "source": item[4], "remark": item[5],
                "imgs": multi, "way": item[7], "department": item[8],
                "date": item[9].strftime('%Y/%m/%d'), "cargo": item[10],
                "position": item[11], "state": status[item[12]], "res": item[13]
            }
            res.append(temp)
    return json.dumps(res, ensure_ascii=False)

# 删除平台动态
@app.route('/api/delete_platform', methods=['GET'])
def delete_platform():
    title = request.args.get('title')
    code = database.delete_platform(title)
    if code == 1:
        return json.dumps({'status': 'ok'})
    else:
        return json.dumps({'status': 'error'})

# 上传平台动态
@app.route('/api/upload_platform', methods=['POST'])
def upload_platform():
    today = datetime.date.today()
    today = today.strftime('%Y/%m/%d')
    title = request.form.get('title')
    title = util.to_normal_char(title)
    owner = request.form.get('owner')
    code = database.store_platform(today, title, owner)
    if code == 1:
        return json.dumps({'status': 'ok'})
    elif code == -1:
        return json.dumps({'status': 'no such user'})
    else:
        return json.dumps({'status': 'error'})

# 获取平台动态
@app.route('/api/get_platform', methods=['GET'])
def get_platform():
    start_str, end_str = None, None
    start_date = request.args.get('start')
    if start_date != None:
        start_obj = datetime.datetime.strptime(start_date, '%Y/%m/%d')
        start_str = start_obj.strftime('%Y-%m-%d')
    end_date = request.args.get('end')
    if end_date != None:
        end_obj = datetime.datetime.strptime(end_date, '%Y/%m/%d')
        end_str = end_obj.strftime('%Y-%m-%d')
    keyword = request.args.get('keyword')
    tmp = database.find_platform(start_str, end_str, keyword)
    res = []
    if tmp:
        for item in tmp:
            temp = {
                "title": item[1], "date": item[2].strftime('%Y-%m-%d')
            }
            res.append(temp)
    return json.dumps(res, ensure_ascii=False)

# 更新若干账号信息
@app.route('/api/update_multi_users', methods=['POST'])
def update_multi_users():
    index = request.form.get('index')
    value = request.form.get('value')
    index = util.to_normal_char(index)
    value = util.to_normal_char(value)
    if len(index) == 0:
        return json.dumps({'status': 'no update'})
    code = database.update_multi(index, value)
    if code == 1:
        return json.dumps({'status': 'ok'})
    else:
        return json.dumps({'status': 'update failed'})

# 忘记密码重置密码
@app.route('/api/reset_password', methods=['GET'])
def reset_password():
    user = request.args.get('username')
    code = database.send_reset(user)
    if code == 1:
        return json.dumps({'status': 'ok'})
    elif code == -1:
        return json.dumps({'status': 'no email address'})
    elif code == 0:
        return json.dumps({'status': 'no such user'})
    else:
        return json.dumps({'status': 'reset failed'})

# 发送授权注册码
@app.route('/api/register_code', methods=['GET'])
def register_code():
    email = request.args.get('email')
    code, str = util.send_code(email)
    if code:
        return json.dumps({'status': 'ok', 'code': str})
    else:
        return json.dumps({'status': 'send failed'})

# 注册
@app.route('/api/register', methods=['POST'])
def register():
    name = request.form.get('username')
    pwd = request.form.get('pwd')
    email = request.form.get('email')
    auth_code = request.form.get('code')
    mac_address = request.form.get('mac')
    code = database.register(name, pwd, email, auth_code, mac_address)
    if code == 1:
        return json.dumps({'status': 'ok'})
    elif code == -1:
        return json.dumps({'status': 'same user'})
    elif code == 2:
        return json.dumps({'status': 'code duplicated'})
    elif code == 3:
        return json.dumps({'status': 'code invalid'})
    else:
        return json.dumps({'status': 'register failed'})

# 查找物种
@app.route('/api/find_sample', methods=['GET'])
def find_sample():
    sample_num = request.args.get('num')
    type = request.args.get('type')
    tmp = database.find_sample_type(sample_num)
    res = []
    if tmp:
        for item in tmp:
            quar = "未知"
            quar_en = "Unknown"
            if int(item[2]) == 0:
                quar = "否"
                quar_en = "NO"
            elif int(item[1]) == 0:
                quar = "检疫性"
                quar_en = "YES"
            des = item[24].replace("\n", "\r\n")
            sub_path = "grassdataset"
            if int(type) == 0:
                sub_path = "insectdataset"
            img_path = image_path + sub_path + '/0' + sample_num + '/'
            img_url = image_url + sub_path + '/0' + sample_num + '/'
            img_content = []
            if(os.path.exists(img_path)):
                images = os.listdir(img_path)
                number = 8 if len(images) > 8 else len(images)
                for i in range(number):
                    img_content.append(img_url + images[i])
            temp = {
                "phylum_cn": item[3], "class_cn": item[6], "order_cn": item[9], "family_cn": item[12], "genus_cn": item[15],
                "species_cn": item[18], "quar": quar, "phylum_latin": item[4], "class_latin": item[7], "order_latin": item[10],
                "family_latin": item[13], "genus_latin": item[16], "species_latin": item[20], "quar_en": quar_en, "des": des,
                "img_urls": img_content
            }
            res.append(temp)
    return json.dumps(res, ensure_ascii=False)

# 添加链接
@app.route('/api/upload_link', methods=['POST'])
def upload_link():
    today = datetime.date.today()
    today = today.strftime('%Y/%m/%d')
    title = request.form.get('title')
    type = request.form.get('type')
    owner = request.form.get('owner')
    url = request.form.get('url')
    url = util.to_normal_char(url)
    level1 = request.form.get('level1')
    level2 = request.form.get('level2')
    level3 = request.form.get('level3')
    level4 = request.form.get('level4')
    code = database.store_file(today, url, title, type, level1, level2, level3, level4, owner)
    if code == 1:
        return json.dumps({'status': 'ok'})
    elif code == -1:
        return json.dumps({'status': 'same title'})
    else:
        return json.dumps({'status': 'same linkname'})

# 删除文件
@app.route('/api/delete_files', methods=['GET'])
def delete_files():
    url = request.args.get('url')
    dist_url = url.replace(pdf_urls, pdfs_path)
    if os.path.exists(dist_url):
        os.remove(dist_url)
    code = database.delete_file(url)
    if code == 1:
        return json.dumps({'status': 'ok'})
    else:
        return json.dumps({'status': 'error'})

# 获取所有用户分类
@app.route('/api/get_user_types', methods=['GET'])
def get_user_types():
    tmp = database.get_user_type()
    res = []
    if tmp:
        for item in tmp:
            res.append(item[0])
    return json.dumps(res, ensure_ascii=False)

# 上传文件
@app.route('/api/upload_file', methods=['POST'])
def upload_file():
    today = datetime.date.today()
    today = today.strftime('%Y/%m/%d')
    file = request.files['file']
    title = request.args.get('title')
    file_type = request.args.get('type')
    level1 = request.args.get('level1')
    level2 = request.args.get('level2')
    level3 = request.args.get('level3')
    level4 = request.args.get('level4')
    owner = request.args.get('owner')
    file_name = request.args.get('name')
    if file is None:
        return json.dumps({'msg': 'File upload fail!'})
    else:
        filename = pdfs_path + str(level1) + '/' + file_name
        fileurl = pdf_urls + str(level1) + '/' + file_name
        if level4 is not None:
            filename = pdfs_path + str(level1) + '/' + str(level2) + '/' + str(level3) + '/' + str(level4) + '/'+ file_name
            fileurl = pdf_urls + str(level1) + '/' + str(level2) + '/' + str(level3) + '/' + str(
                level4) + '/' + file_name
        elif level3 is not None:
            filename = pdfs_path + str(level1) + '/' + str(level2) + '/' + str(level3) + '/' + file_name
            fileurl = pdf_urls + str(level1) + '/' + str(level2) + '/' + str(level3) + '/' + file_name
        elif level2 is not None:
            filename = pdfs_path + str(level1) + '/' + str(level2) + '/' + file_name
            fileurl = pdf_urls + str(level1) + '/' + str(level2) + '/' + file_name
        file.save(filename)
        if os.path.exists(filename):
            code = database.store_file(today, fileurl, title, file_type, level1, level2, level3, level4, owner)
            if code == 1:
                return json.dumps({'status': 'ok'})
            elif code == -1:
                return json.dumps({'status': 'same title'})
            elif code == -2:
                return json.dumps({'status': 'same filename'})
        return json.dumps({'status': 'error'})

# 获取用户信息
@app.route('/api/get_users', methods=['GET'])
def get_users():
    auth = ["普通", "管理员"]
    keyword = request.args.get('keyword')
    type = request.args.get('type')
    tmp = database.search_allusers(type, keyword)
    res = []
    if tmp:
        for item in tmp:
            temp = {
                "name": item[1], "pwd": item[2], "auth": auth[item[3]], "type": item[4], "acname": item[5], "department": item[6],
                "region": item[7], "work_year": '' if item[8] is None else str(item[8]) + '年',
                "user_title": item[9]
            }
            res.append(temp)
    return json.dumps(res, ensure_ascii=False)

# 更新账号信息
@app.route('/api/update_account', methods=['POST'])
def update_account():
    user = request.form.get('username')
    oripwd = request.form.get('oripwd')
    curpwd = request.form.get('curpwd')
    type = request.form.get('type')
    name = request.form.get('name')
    department = request.form.get('department')
    region = request.form.get('region')
    year = request.form.get('year')
    title = request.form.get('title')
    code = database.update_acc(user, oripwd, curpwd, type, name, department, region, year, title)
    if code == 1:
        return json.dumps({'status': 'ok'})
    elif code == 0:
        return json.dumps({'status': 'pwd error'})
    else:
        return json.dumps({'status': 'update error'})

# 获取用户具体信息
@app.route('/api/get_user_info', methods=['GET'])
def get_user_info():
    user = request.args.get('username')
    tmp = database.search_user(user)
    res = []
    if tmp:
        for item in tmp:
            temp = {
                "type": item[4], "name": item[5], "department": item[6],
                "region": item[7], "work_year": '' if item[8] is None else str(item[8]) + '年',
                "user_title": item[9]
            }
            res.append(temp)
    return json.dumps(res, ensure_ascii=False)

# 获取包含条件的申报信息
@app.route('/api/get_declare_records', methods=['GET'])
def get_declare_records():
    types = ["昆虫", "杂草"]
    ways = ["离线鉴定", "在线鉴定"]
    status = ["未鉴定", "已鉴定"]
    user = request.args.get('username')
    way = request.args.get('way')
    start_date = request.args.get('start')
    start_obj = datetime.datetime.strptime(start_date, '%Y/%m/%d')
    start_str = start_obj.strftime('%Y-%m-%d')
    end_date = request.args.get('end')
    end_obj = datetime.datetime.strptime(end_date, '%Y/%m/%d')
    end_str = end_obj.strftime('%Y-%m-%d')
    keyword = request.args.get('keyword')
    state = request.args.get('status')
    tmp = database.search_declare_with_details(user, way, start_str, end_str, keyword, state)
    res = []
    if tmp:
        for item in tmp:
            temp = {
                "num": item[2], "department": item[8], "person": user,
                "date": item[9].strftime('%Y-%m-%d'), "type": types[item[3]],
                "cargo": item[10], "country": item[4], "position": item[11],
                "way": ways[item[7]], "status": status[item[12]], "res": item[13]
            }
            res.append(temp)
    return json.dumps(res, ensure_ascii=False)

# 获取申报信息
@app.route('/api/get_declares', methods=['GET'])
def get_declares():
    types = ["昆虫", "杂草"]
    ways = ["离线鉴定", "在线鉴定"]
    status = ["未鉴定", "已鉴定"]
    user = request.args.get('username')
    way = request.args.get('way')
    tmp = database.get_declare_records(user, way)
    res = []
    if tmp:
        for item in tmp:
            temp = {
                "num": item[2], "department": item[8], "person": user,
                "date": item[9].strftime('%Y-%m-%d'), "type": types[item[3]],
                "cargo": item[10], "country": item[4], "position": item[11],
                "way": ways[item[7]], "status": status[item[12]], "res": item[13]
            }
            res.append(temp)
    return json.dumps(res, ensure_ascii=False)

# 存储申报信息
@app.route('/api/submit_declare', methods=['POST'])
def submit_declare():
    user = request.args.get('username')
    num = request.args.get('num')
    type = request.args.get('type')
    country = request.args.get('country')
    remark = request.args.get('remark')
    files = request.files.getlist('file')
    way = request.args.get('way')
    department = request.args.get('department')
    date = request.args.get('date')
    date_obj = datetime.datetime.strptime(date, '%Y/%m/%d')
    date_str = date_obj.strftime('%Y-%m-%d')
    cargo = request.args.get('cargo')
    position = request.args.get('pos')
    filenames = []
    res = ""
    status = 0
    for file in files:
        name = str(hash(file.filename.split('.')[0]))
        file_type = file.filename.split('.')[-1]
        filename = declare_path + name + '.' + file_type
        file.save(filename)
        if os.path.exists(filename):
            filenames.append(filename)
            if int(way) == 0:
                number, objName = datatest.identify(filename, int(type))
                if res == "":
                    res = number
                    status = 1
        else:
            return json.dumps({'status': 'update failed'})
    code = database.store_declares(user, num, int(type), country, remark, filenames, int(way), department, date_str, cargo, position, status, res)
    if code == 1:
        return json.dumps({'status': 'ok'})
    else:
        return json.dumps({'status': 'insert error'})

# 获取分类文件信息
@app.route('/api/get_detail_files', methods=['GET'])
def get_detail_files():
    type = request.args.get('class')
    start_date = request.args.get('start')
    start_str, end_str = None, None
    if start_date != None:
        start_obj = datetime.datetime.strptime(start_date, '%Y/%m/%d')
        start_str = start_obj.strftime('%Y-%m-%d')
    end_date = request.args.get('end')
    if end_date != None:
        end_obj = datetime.datetime.strptime(end_date, '%Y/%m/%d')
        end_str = end_obj.strftime('%Y-%m-%d')
    keyword = request.args.get('keyword')
    file_type = request.args.get('type')
    tmp = database.search_files_with_details(file_type, type, start_str, end_str, keyword)
    res = []
    if tmp:
        for item in tmp:
            temp = {"name": item[1], "date": item[2].strftime('%Y-%m-%d'), "url": item[3], "type": item[4]}
            res.append(temp)
    return json.dumps(res, ensure_ascii=False)

# 获取分类文件信息
@app.route('/api/get_files', methods=['GET'])
def get_files():
    type = request.args.get('class')
    level2 = request.args.get('level2')
    level3 = request.args.get('level3')
    level4 = request.args.get('level4')
    file_type = request.args.get('type')
    tmp = database.search_files(file_type, type, level2, level3, level4)
    res = []
    if tmp:
        for item in tmp:
            temp = {"name": item[1], "date": item[2].strftime('%Y-%m-%d'), "url": item[3], "type": item[4]}
            res.append(temp)
    return json.dumps(res, ensure_ascii=False)

# 历史鉴定
@app.route('/api/search_history', methods=['GET'])
def search_history():
    date = request.args.get('date')
    tmp = database.search_history(date)
    res = []
    for item in tmp:
        temp = {"num": item[0], "date": date, "img": None, "res": item[3]}
        img_stream = ''
        with open(item[2], 'rb') as img_f:
            img_stream = img_f.read()
            img_stream = base64.b64encode(img_stream)
            img_stream = img_stream.decode('utf-8')
            temp["img"] = img_stream
        res.append(temp)
    return json.dumps(res)

# 保存鉴定历史
@app.route('/api/store', methods=['POST'])
def store():
    today = datetime.date.today()
    today = today.strftime('%Y/%m/%d')
    img = request.files['file']
    res = request.args.get('res')
    if img is None:
        return json.dumps({'msg': 'File upload fail!'})
    else:
        name = str(hash(img.filename.split('.')[0]))
        type = img.filename.split('.')[-1]
        filename = store_path + name + '.' + type
        img.save(filename)
        if os.path.exists(filename):
            code = database.store(today, filename, res)
            if code == 1:
                return json.dumps({'status': 'ok'})
            else:
                return json.dumps({'status': 'insert error'})
        return json.dumps({'status': 'error'})

# 智能识别
@app.route('/api/identify', methods=['POST'])
def identify():
    img_class = request.args.get('type')
    img = request.files['file']
    if img is None:
        return json.dumps({'msg': 'File upload fail!'})
    else:
        name = str(hash(img.filename.split('.')[0]))
        type = img.filename.split('.')[-1]
        filename = img_path + name + '.' + type
        img.save(filename)
        if os.path.exists(filename):
            num, objName = datatest.identify(filename, int(img_class))
            return json.dumps({'status': 'ok', 'num': num, 'name':objName}, ensure_ascii=False)
        return json.dumps({'status': 'error'})

# 登录
@app.route('/api/login', methods=['POST'])
def login():
    user = request.form.get('username')
    pwd = request.form.get('pwd')
    mac_address = request.form.get('mac')
    code, auth = database.login(user, pwd, mac_address)
    if code == 0:
        return json.dumps({'status': 'invalid user'})
    elif code == 1:
        return json.dumps({'status': 'match', 'username': user, 'auth': auth})
    elif code == 2:
        return json.dumps({'status': 'pwd error'})
    else:
        return json.dumps({'status': 'invalid device'})

def init_log(log_name):
    """
    初始化日志
    :return:
    """
    logging.basicConfig(level=logging.INFO)  # 调试debug级(开发环境)
    file_log_handler = RotatingFileHandler("{}/logs/{}.log".format(path_of_current_dir, log_name), maxBytes=1024 * 1024 * 100, backupCount=10)  # 100M
    formatter = logging.Formatter('%(asctime)s %(levelname)s: %(filename)s:%(lineno)d %(message)s')  # 时间,日志级别,记录日志文件,行数,信息
    # 将日志记录器指定日志的格式
    file_log_handler.setFormatter(formatter)
    # 日志等级的设置
    # 为全局的日志工具对象添加日志记录器
    logging.getLogger().addHandler(file_log_handler)

if __name__ == '__main__':
    app.config['JSON_AS_ASCII'] = False
    app.run(host = '0.0.0.0')
