from math import sin
import numpy as np
import matplotlib.pyplot as plt


def functionG(u, g, t):
    return 3 * u - 2 * g + 2 * sin(t)


def functionU(u, g, t):
    return 5 * u - 8 * g


def method_runge_kutta(f1, f2, xn, xk, yn, zn, t):
    h = 0.6 / 15
    steps = 15
    z = np.zeros(steps)
    x = np.linspace(xn, xk, steps)
    y = np.zeros(steps)
    y[0] = yn
    z[0] = zn
    print(f"t = {t[0]}        g = {z[0]}         u = {y[0]}")
    for i in range(1, steps):
        q1 = h * f2(x[i - 1], y[i - 1], z[i - 1])
        k1 = h * f1(x[i - 1], y[i - 1], z[i - 1])
        q2 = h * f2(x[i - 1] + h / 2, y[i - 1] + (k1) / 2.0, z[i - 1] + (q1) / 2.0)
        k2 = h * f1(x[i - 1] + h / 2, y[i - 1] + (k1) / 2.0, z[i - 1] + (q1) / 2.0)
        q3 = h * f2(x[i - 1] + h / 2, y[i - 1] + k2 / 2.0, z[i - 1] + (q2) / 2.0)
        k3 = h * f1(x[i - 1] + h / 2, y[i - 1] + k2 / 2.0, z[i - 1] + (q2) / 2.0)
        q4 = h * f2(x[i - 1] + x[i - 1], y[i - 1] + k3, z[i - 1] + q3)
        k4 = h * f1(x[i - 1] + x[i - 1], y[i - 1] + k3, z[i - 1] + q3)

        z[i] = z[i - 1] + (q1 + 2 * q2 + 2 * q3 + q4) / 6.0
        y[i] = y[i - 1] + (k1 + 2 * k2 + 2 * k3 + k4) / 6.0

        print('t = %1.2f ' % x[i], '     g = %1.3f ' % z[i], '     u = %1.3f' % y[i])
    return x, z, y


funG = np.zeros(15)
funU = np.zeros(15)
t = np.zeros(15)

u0 = 0.3
g0 = 0.5
t0 = 0

funG[0] = g0
funU[0] = u0
t[0] = t0

t, funG, funU = method_runge_kutta(functionG, functionU, 0, 0.6, g0, u0, t)

sum_x = np.sum(funG)
sum_y = np.sum(funU)
sum_x_2 = np.sum(funG ** 2)
sum_x_y = np.sum(funG * funU)

A = (15 * sum_x_y - sum_x * sum_y) / (15 * sum_x_2 - sum_x ** 2)
B = (sum_y - A * sum_x) / 15

t[0] = -0.5

plt.plot(funG, funU, 'o')
plt.plot(funG, funU)
P = A * t + B
plt.plot(t, P)
plt.show()

