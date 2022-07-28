from functools import *
from re import L

file = open("HRMasterlist.txt")
HRList = []
for f in file:

    line = f.split('|')
    HRList.append(line)
file.close


# def function():
#     x = 0
#     for i in HRList:
#         if float(i[3][6:10]) > 1995:
#             # print(i[3][6:10])
#             x += (float(i[8]))*0.85
#             # print(i[8])
#     return x


# print(function())

# test2 = filter(lambda x: str(x[7]) == "FullTime", HRList)


result = (reduce(lambda x, y: x+y, map(lambda x: int(x[8])*0.85, filter(lambda x: int(x[3][6:10]) > 1995, filter(
    lambda x: str(x[7]) == "FullTime", HRList)))))

print(f'Total New Salary {result}')
