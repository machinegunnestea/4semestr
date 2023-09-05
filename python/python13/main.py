import numpy as np
import matplotlib.pyplot as plt
import math

a = 1.5
b = 2
e = 0.00001
G = 0.015
r = 0.015
h = 1.2
R = 12


def f(l):
    return (np.log(((6 * l) ** 2) / (2 * r * h)) + 4.95) / (math.pi * 2 * 6 * l * G) - R


y1 = f(a)
y2 = f(b)

if y1 * y2 >= 0:
    print('Корней нет')
    c = 1
else:
    n = 1
    c = (a + b) / 2
    y3 = f(c)
    while (abs(y3) > e):
        c = (a + b) / 2
        y3 = f(c)
        if y1 * y3 < 0:
            b = c
        else:
            a = c
        n += 1

x = np.arange(1.7, 2.5, 0.01)
plt.plot(x, f(x), 'y')
plt.plot(c, f(c), 'ro')
print('c = %0.2f ' % c)
print(c)
plt.grid()
plt.show()
