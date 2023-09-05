from scipy.integrate import quad
from math import *
import numpy as np
import sympy as smp
import matplotlib.pyplot as plt


x=smp.symbols('x')
fn= smp.sin(x**2)*x # символьное выражение уравнения
f= smp.sqrt(1+fn.diff(x)**2)# подынтегральное символьное выражение
g=smp.lambdify(x, f, "numpy") # преобразование в выражение numpy
L=quad(g,0,pi) # вычисление интеграла
print(L) # значение интеграла и точность
# грфик цепной линии
fig = plt.figure(facecolor='white') #,xlim=(-2,2), ylim=(0,4))
ax = plt.axes(xlim=(-2, 2), ylim=(-2, 4))
fun=smp.lambdify(x, fn, "numpy")
x=np.linspace(-2,2,81)
ax.plot(x,fun(x),lw=1.5)
ax.grid(True)
plt.show()