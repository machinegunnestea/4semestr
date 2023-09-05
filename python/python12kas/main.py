#метод касательных
import math
import numpy as np
import matplotlib.pyplot as plt
from scipy.misc import derivative


def F(x):
    return 0.5 * x ** 4 - 1.1 * x ** 3 - 7 * x ** 2 + 13.7 * x - 6.6


def F1(x):
     return derivative(F, x, dx=1e-6)

def Method(a, b):
    x0 = (a + b) / 2
    xn = F(x0)
    xn1 = xn - F(xn) / F1(xn)
    while abs(xn1 - xn) > math.pow(10, -5):
        xn = xn1
        xn1 = xn - F(xn) / F1(xn)
    return xn1

a = 0
b = 5
dx = 1
x1 = a
la = [0]
lb = [0]
while x1 <= b - dx:
     x2 = x1 + dx
     if F(x1) * F(x2) < 0:
         la += [x1]
         lb += [x2]
     x1 = x2
for i in range(1, len(la)):
    print('%8.2f' % la[i], '%8.2f' % lb[i])
    print(Method(a, b))
    num = (Method(a, b))

