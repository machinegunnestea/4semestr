import numpy as np
import matplotlib.pyplot as plt

def PrintAB(x):
    S = 0
    for k in range(1, n + 1):
        Sak = 0
        Sbk = 0
        for j in range(N):
            Sak += Y[j] * np.cos(k * X[j])
            Sbk += Y[j] * np.sin(k * X[j])
        ak = 2 / N * Sak  # коэффицент a
        bk = 2 / N * Sbk  # коэффицент b
        print("Коэфф а: ", ak, " Коэфф b: ", bk, "\n")

def f(x):
    S = 0
    for k in range(1,n+1):
        Sak=0
        Sbk=0
        for j in range(N):
            Sak += Y[j]*np.cos(k*X[j])
            Sbk += Y[j]*np.sin(k*X[j])
        ak = 2/N * Sak # коэффицент a
        bk = 2/N * Sbk # коэффицент b
        S += ak * np.cos(k*x) + bk * np.sin(k*x) # подсчет ряда
    G = a0 + S # ряд Фурье

    return G


trashold_value = 2
Y = np.array(
    [1.01, 1.34, 1.75, 2.18, 2.53, 2.71, 2.65, 2.37, 1.97, 1.54, 1.66, 0.86, 0.64, 0.5, 0.42, 0.37, 0.36, 0.39, 0.45, 0.56, 0.77])  # начальны значение Yj
N = len(Y)  # 2n+1, j принадлежит диапазону от 1 до 2n+1
n = int((N - 1) / 2)
X = []  # 1) нахождение Хj
for i in range(1, N + 1):
    X.append(2 * np.pi * (i - 1) / N)
X = np.array(X)
print(X)  # вывод в консоль Xj
a0 = 1 / N * sum(Y)  # 2) коэффицен а0

plt.scatter(X, Y)
x = np.linspace(X.min(), X.max(), 1000)
t = np.arange(0, 6, 0.01)
plt.plot(x, f(x))

PrintAB(x)

x0 = 0
while f(x0) > trashold_value:
    x0 += 0.01
xp = x0
plt.scatter(xp, f(xp))

x1 = xp + 0.01
while f(x1) < trashold_value:
    x1 += 0.01
xp2 = x1 - 0.01
print("xp2: ",xp2, " f(xp2): ",f(xp2))
plt.scatter(xp2, f(xp2), color='orange')

plt.grid(True)
plt.xlabel("X")
plt.ylabel("Y")
x0, y1 = [X.min(), X.max()], [trashold_value, trashold_value]
plt.plot(x0, y1)
plt.show()