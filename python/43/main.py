import matplotlib.pyplot as plt
import numpy as np


def f(t, y):
    f = np.zeros(4)
    f[0] = y[1]
    f[1] = -k / m * y[1]
    f[2] = y[3]
    f[3] = -k / m * y[3] - g

    return f


def runge_kutta_method(t0, y0, h):
    ti = t0
    yi = y0

    result_t = np.array(ti)
    result_y = np.array(yi)

    while yi[2] >= 0:
        k1 = h * f(ti, yi)
        k2 = h * f(ti + h / 2, yi + k1 / 2)
        k3 = h * f(ti + h / 2, yi + k2 / 2)
        k4 = h * f(ti + h, yi + k3)

        yi += 1 / 6 * (k1 + 2 * k2 + 2 * k3 + k4)
        ti += h

        result_t = np.vstack((result_t, ti))
        result_y = np.vstack((result_y, yi))

    return result_t, result_y


t0 = 0
theta = np.pi / 4
v0 = 10
k = 0.05
g = 9.8
m = 0.3
y0 = np.array([0, v0 * np.cos(theta), 0, v0 * np.sin(theta)])
h = 0.01

result_t, result_y = runge_kutta_method(t0, y0, h)

plt.plot(result_y[:, 0], result_y[:, 2])
plt.title('Траектория брошенного снаряда')
plt.xlabel('X')
plt.ylabel('Y')
plt.grid()
plt.show()
