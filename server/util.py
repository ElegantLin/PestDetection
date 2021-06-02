import config
import smtplib
from email.mime.text import MIMEText
import random
import string

def to_normal_char(value):
    if value is None or len(value) == 0:
        return ''
    value = value.replace("%2B", "+")
    value = value.replace("%20", " ")
    value = value.replace("%2F", "/")
    value = value.replace("%3F", "?")
    value = value.replace("%25", "%")
    value = value.replace("%23", "#")
    value = value.replace("%26", "&")
    value = value.replace("%3D", "=")
    value = value.replace("%5C", '\'')
    value = value.replace("%2E", ".")
    value = value.replace("%3A", ":")
    return value

def send_mail(to_list, sub, content):
    me = "hello" + "<" + config.mail_user + "@" + config.mail_postfix + ">"
    msg = MIMEText(content,_subtype='plain',_charset='gb2312')
    msg['Subject'] = sub
    msg['From'] = me
    msg['To'] = ";".join(to_list)
    try:
        server = smtplib.SMTP()
        server.connect(config.mail_host)
        server.login(config.mail_user, config.mail_pass)
        server.sendmail(me, to_list, msg.as_string())
        server.close()
        return True
    except Exception as e:
        print(e)
        return False

def send_to_user(user, email):
    ran_str = ''.join(random.sample(string.ascii_letters + string.digits, 8))
    mailto_list = [email]
    if send_mail(mailto_list, "动植检管理系统重置密码", user + " 的新密码为" + ran_str + "，请使用新密码登录并修改密码"):
        return True, ran_str
    else:
        return False, None

def send_code(email):
    ran_str = ''.join(random.sample(string.ascii_letters + string.digits, 6))
    mailto_list = [email]
    if send_mail(mailto_list, "动植检管理系统注册授权码", "注册授权码为" + ran_str + "，请使用该注册授权码完成注册"):
        return True, ran_str
    else:
        return False, None
