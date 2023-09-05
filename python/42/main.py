import math

import numpy as np
from math import*
import matplotlib.pyplot as plt

def f(x, y):
    f = np.zeros((2), 'float')
    f[0] = y[1]
    f[1] = 16*x*math.exp(2*x) + 4*y[0] - 20*y[1]
    return f


def rk(f, t0, y0, h):
    def danrk(f, t,y, h):
        k0 = h * f(t, y)
        k1 = h * f(t + h/2., y + k0/2.)
        k2 = h * f(t + h/2., y + k1 / 2.)
        k3 = h * f(t + h, y + k2)
        return (k0 + 2. * k1 + 2. * k2 + k3)/6
    t = []
    y = []
    t.append(t0)
    y.append(y0)
    while t0 < tn:
        y0 = y0 + danrk(f, t0, y0, h)
        t0 = t0 + h
        t.append(t0)
        y.append(y0)
    return np.array(t), np.array(y)

t0 = 0.
tn = 2
y0 = np.array([2, 2])
h = 0.01
t1, y1 = rk(f, t0, y0, h)
r = y1[:, 0]
k = y1[:, 1]
plt.plot(t1, r)
plt.plot(t1, k)
plt.xlabel('x', fontsize=14)
plt.ylabel('y', fontsize=14)
plt.grid()
plt.show()