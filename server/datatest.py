import numpy as np
import pandas as pd
from keras.models import load_model
from PIL import Image
from keras.preprocessing import image

# 昆虫是0，杂草是1

def identify(img_path, type_name):
    width = 360
    height = 270
    typenum = 242
    target_data_table = None
    if type_name == 0:
        target_data = pd.read_csv('insectname.csv', encoding = 'gbk')
        target_data_table = pd.DataFrame(target_data, columns = target_data.columns)
        model = load_model('output/insect_model.h5')
    elif type_name == 1:
        target_data = pd.read_csv('grassname.csv', encoding = 'gbk')
        target_data_table = pd.DataFrame(target_data, columns = target_data.columns)
        model = load_model('output/grass_model.h5')

    num_indices = dict((i, c) for i,c in enumerate(target_data_table.Num, start = 1))
    name_indices = dict((i, c) for i,c in enumerate(target_data_table.Name, start = 1))

    img = Image.open(img_path)
    raw_img = img.resize((width, height), Image.ANTIALIAS).convert('L')
    X_test = np.zeros((1, height, width, 1), dtype=np.float32)
    X_test[0] = image.img_to_array(raw_img)

    result = model.predict(X_test)

    num = []
    name = []
    vec = result[0]
    vec[vec < max(vec)] = 0
    char_pos = vec.nonzero()[0]
    for i, ch in enumerate(char_pos):
        num.append(num_indices[ch + 1])
        name.append(name_indices[ch + 1])

    if max(result[0]) > 0.5:
        return num[0], name[0]
    else:
        return '', '识别失败'
