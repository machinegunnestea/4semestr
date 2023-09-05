import numpy as np
from matplotlib import pyplot as plt


def uf(u, z, t):
    return 2 * u - 3 * z



def zf(u, z, t):
    return u - 5 * z + 5 * np.cos(t)



x0 = 0
xk = 2
n = 12
h = (xk - x0) / n
n = 13
u = np.zeros(n)
z = np.zeros(n)
t = np.zeros(n)

t[0] = 0
u[0] = 1.4
z[0] = 0

i = 1
while i < n:
    k0 = uf(u[i - 1], z[i - 1], t[i - 1])
    q0 = zf(u[i - 1], z[i - 1], t[i - 1])
    k1 = uf(u[i - 1] + k0 * h / 2, z[i - 1] + k0 * h / 2, t[i - 1] + h / 2)
    q1 = zf(u[i - 1] + k0 * h / 2, z[i - 1] + q0 * h / 2, t[i - 1] + h / 2)
    k2 = uf(u[i - 1] + k1 * h / 2, z[i - 1] + k1 * h / 2, t[i - 1] + h / 2)
    q2 = zf(u[i - 1] + k1 * h / 2, z[i - 1] + q1 * h / 2, t[i - 1] + h / 2)
    k3 = uf(u[i - 1] + k2 * h, z[i - 1] + k2 * h, t[i - 1] + h)
    q3 = zf(u[i - 1] + k2 * h, z[i - 1] + q2 * h, t[i - 1] + h)
    z[i] = z[i - 1] + h / 6 * (q0 + 2 * q1 + 2 * q2 + q3)
    u[i] = u[i - 1] + h / 6 * (k0 + 2 * k1 + 2 * k2 + k3)
    t[i] = t[i - 1] + h
    i += 1

for i in range(n):
    print(str(t[i]) + " " + str(u[i]) + " " + str(z[i]))

    plt.grid()
    plt.plot(t, z)


def sum_x2y(arr_x, arr_y):
    i = 0
    t = 0
    while i < len(arr_x):
        t += arr_y[i] * arr_x[i] ** 2
        i += 1
    return t


def sum_xy(arr_x, arr_y):
    i = 0
    t = 0
    while i < len(arr_x):
        t += arr_x[i] * arr_y[i]
        i += 1
    return t


def sum4(arr):
    i = 0
    t = 0
    while i < len(arr):
        t += arr[i] ** 4
        i += 1
    return t


def sum3(arr):
    i = 0
    t = 0
    while i < len(arr):
        t += arr[i] ** 3
        i += 1
    return t


def sum2(arr):
    i = 0
    t = 0
    while i < len(arr):
        t += arr[i] ** 2
        i += 1
    return t


def sum(arr):
    i = 0
    t = 0
    while i < len(arr):
        t += arr[i]
        i += 1
    return t


def f(_x):
    return C[0] * _x ** 2 + C[1] * _x + C[2]


A = np.array([[sum4(t), sum3(t), sum2(t)],
[sum3(t), sum2(t), sum(t)],
[sum2(t), sum(t), len(t)]])

B = np.array([[sum_x2y(t, z)],
[sum_xy(t, z)],
[sum(z)]])

C = np.dot(np.linalg.inv(A), B)

p = np.linspace(0, 2, 12)
plt.plot(p, f(p), '-y')
plt.show()

a = 0
b = 2
e = 0.01

def trap(n):
    s = 0
    s0 = 1
    while np.fabs(s0 - s) > e:
        s0 = s
        n = 2 * n
        h = (b - a) / n
        sum = 0
        x = 0
        i = 1
    while i < n:
        x += h
        sum += f(x)
        i += 1
        s = h * ((f(a) + f(b)) / 2 + sum)
    return s
    print(trap(n))