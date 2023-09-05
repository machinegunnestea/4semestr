import numpy as np
import matplotlib.pyplot as plt
from sympy import *


def f(x):
    return 3 * x**2 + 38 * x + 2


def Powell(xn, delta):
    x0 = xn
    x1 = x0 + delta
    x2 = 0
    y0 = f(x0)
    y1 = f(x1)
    y2 = 0
    if y0 < y1:
        x2 = x0 - delta
    else:
        x2 = x0 + 2 * delta
    steps = 0
    while True:
        steps += 1
        y0 = f(x0)
        y1 = f(x1)
        y2 = f(x2)
        a0 = y0
        a1 = (y1 - y0) / (x1 - x0)
        a2 = (1 / (x2 - x1)) * (((y2 - y0) / (x2 - x0)) - ((y1 - y0) / (x1 - x0)))
        xz = ((x1 + x0) / 2) - (a1 / (2 * a2))
        if x0 >= x1 <= x2:
            if (x1 - xz) < e:
                return xz, steps
        elif x1 >= x0 <= x2:
            if (x0 - xz) < e:
                return xz, steps
        else:
            if (x2 - xz) < e:
                return xz, steps
        if y1 <= y0 >= y2:
            x0 = xz
        elif y0 <= y1 >= y2:
            x1 = xz
        else:
            x2 = xz


def PowellAccurate():
    xe = Symbol('x', real=True)
    fone = 3* xe ** 2 + 38 * xe +1
    derivative = fone.diff(xe)
    result = solve(derivative, xe)
    return derivative, result


xn = 8
e = 0.2
result, stepsP = Powell(xn, 5)
derivative, res = PowellAccurate()
print("Ответ", result)
print(f"Производная функции:{derivative}\nТочный ответ: {res}")

arrx = np.linspace(-25, 10, 100)
arry = f(arrx)
plt.plot(arrx, arry)
plt.plot(result, f(result), 'ro', color="red")
plt.grid()
plt.show()


