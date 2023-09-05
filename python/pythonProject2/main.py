from math import *
import numpy as np
import matplotlib.pyplot as plt

def f(x, y):
    return x - 2*y - np.cos(x)
##########AAAAAAAA
def methodRungeKutta():
    i = 1
    n = int((x2 - x1) / h) + 1
    y = np.zeros(n)
    x = np.zeros(n)
    y[0] = 0
    x[0] = 0
    while i < n:
        k1 = f(x[i - 1], y[i - 1])
        k2 = f(x[i - 1] + h / 2, y[i - 1] + h * k1 / 2)
        k3 = f(x[i - 1] + h / 2, y[i - 1] + h * k2 / 2)
        k4 = f(x[i - 1] + h, y[i - 1] + h * k3)
        y[i] = y[i - 1] + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4)
        x[i] = x[i - 1] + h
        i += 1
    return y, x
##########BBBBBBB
x1 = 0
x2 = 1
plt.grid()
h = 0.1
y, x = methodRungeKutta()
print("x = ", x)
print("y = ", y)
plt.scatter(x,y)
plt.plot(x, y)

def sum_x2y(arr_x, arr_y):
    i = 0;
    t = 0
    while (i < len(arr_x)):
        t += arr_y[i] * arr_x[i] ** 2
        i += 1
    return t

def sum_xy(arr_x, arr_y):
    i = 0;
    t = 0
    while (i < len(arr_x)):
        t += arr_x[i] * arr_y[i]
        i += 1
    return t

def sum4(arr):
    i = 0;
    t = 0
    while (i < len(arr)):
        t += arr[i] ** 4
        i += 1
    return t

def sum3(arr):
    i = 0;
    t = 0
    while (i < len(arr)):
        t += arr[i] ** 3
        i += 1
    return t

def sum2(arr):
    i = 0;
    t = 0
    while (i < len(arr)):
        t += arr[i] ** 2
        i += 1
    return t

def sum(arr):
    i = 0;
    t = 0
    while (i < len(arr)):
        t += arr[i]
        i += 1
    return t

def f(x, X):
    return X[0] * x ** 2 + X[1] * x + X[2]

A = np.array(
    [[sum4(x), sum3(x), sum2(x)],
     [sum3(x), sum2(x), sum(x)],
     [sum2(x), sum(x), len(x)]])

B = np.array(
    [[sum_x2y(x, y)],
     [sum_xy(x, y)],
     [sum(y)]])

X = np.array(
    [[0],
     [0],
     [0]])
X = np.dot(np.linalg.inv(A), B)

plt.figure(1)
plt.grid()
p = np.linspace(0, 10, 1)
plt.plot(x, y)
print("X = ", X)
#########dddddddddd
def Gold(a, b, eps):
    fi = (1 + sqrt(5)) / 2
    n = 0
    while (fabs(b - a) > eps):
        n = n + 1
        x1 = b - (b - a) / fi
        x2 = a + (b - a) / fi
        if (f(x1, X) >= f(x2, X)):
            a = x1
        else:
            b = x2
    return (a + b) / 2, n

a = 0
b = 1
eps = 0.01

gext, gn = Gold(a, b, eps)

print("Золотое сечение:\next = %f" %gext)

x = np.arange(a, b, eps)
plt.plot(gext, f(gext, X), 'x', label='Золотое сечение', color="r")
plt.grid()
plt.legend()
plt.show()

