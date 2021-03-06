# -*- coding: utf-8 -*-
"""DataSet.ipynb

Automatically generated by Colaboratory.

Original file is located at
    https://colab.research.google.com/drive/1xYpowmd3fq1-4A2xCJncQihZ6b6CP28Z
"""

import bisect as bi
import pandas as pd
import random as rn
import numpy as np

# модуль с функциями

from math import *

def f1(x):
    return 1/6*x**6 - 52/25*x**5 + 39/80*x**4 + 71/10*x**3 - \
        79/20*x**2 - x + 1/10

def f2(x):
    return sin(x) + sin(10*x/3)

def f3(x):
    sum = 0
    for k in range(1, 6):
        sum += k*sin((k + 1)*x + k)
    return -sum

def f4(x):
    return -(16*x**2 - 24*x + 5)*exp(-x)

def f5(x):
    return (3*x - 1.4)*sin(18*x)

def f6(x):
    return -(x + sin(x))*exp(-x**2)

def f7(x):
    return sin(x) + sin(10*x/3) + log(x) - 0.84*x + 3

def f8(x):
    sum = 0
    for k in range(1, 6):
        sum += k*cos((k + 1)*x + k)
    return -sum

def f9(x):
    return sin(x) + sin(2*x/3)

def f10(x):
    return -x*sin(x)

def f11(x):
    return 2*cos(x) + cos(2*x)

def f12(x):
    return sin(x)**3 + cos(x)**3

def f13(x):
    return -pow(x, 2/3) - pow(-x**2 + 1, 1/3)

def f14(x):
    return -exp(-x)*sin(2*pi*x)

def f15(x):
    return (x**2 - 5*x + 6)/(x**2 + 1)

def f16(x):
    return 2*(x - 3)**2 + exp(0.5*x**2)

def f17(x):
    return x**6 - 15*x**4 + 27*x**2 + 250

def f18(x):
    if x <= 3:
        return (x - 2)**2
    return 2*log(x - 2) + 1

def f19(x):
    return -x + sin(3*x) - 1

def f20(x):
    return (sin(x) - x)*exp(-x**2)

func = [(f1, -1.5, 11), (f2, 2.7, 7.5), (f3, -10, 10), (f4, 1.9, 3.9),
    (f5, 0, 1.2), (f6, -10, 10), (f7, 2.7, 7.5), (f8, -10, 10), (f9, 3.1, 20.4), (f10, 0, 10),
    (f11, -1.57, 6.28), (f12, 0, 6.28), (f13, 0.001, 0.99), (f14, 0, 4), (f15, -5, 5),
    (f16, -3, 3), (f17, -4, 4), (f18, 0, 6), (f19, 0, 6.5), (f20, -10, 10)]

class Point():
    def __init__(self, x, z):
        self.x = x
        self.z = z
    def __repr__(self):
        return f"Point({self.x}, {self.z})"
    def __str__(self):
        return f"Point({self.x}, {self.z})"
    def __lt__(self, other):
        return self.x < other.x

def simpleMinFunc(f, a, b, EPS):
    x = a
    xMin = x
    yMin = f(xMin)
    k = 0
    is_b = False
    while True:
        y = f(x)
        if y < yMin:
            yMin = y
            xMin = x
        if x + EPS < b:
            x += EPS
        elif not is_b:
            x = b
            is_b = True
        else:
            break
        
        k += 1

    return xMin, k

def step1(w, k, KSI, r, mu, df, EPS, f, a, b):
    gamma = [0.1]*(k + 1)
    lam = [0.1]*(k + 1)

    # X^max = max{x_i - x_i-1}
    Xmax = -1
    for i in range(1, k + 1):
        if w[i].x - w[i - 1].x > Xmax:
            Xmax = w[i].x - w[i - 1].x
    
    # lambda^max = max|z_i - z_i-1|/(x_i - x_i-1)
    lmax = -1
    for i in range(1, k + 1):
        cur = abs(w[i].z - w[i - 1].z) / (w[i].x - w[i - 1].x)
        if cur > lmax:
            lmax = cur
    
    for i in range(1, k + 1):
        gamma[i] = lmax * (w[i].x - w[i - 1].x) / Xmax
    
    # lambda_i = max{|z_j - z_j-1|/(x_j - x_j-1) : j = i - 1, i, i + 1}
    for i in range(1, k + 1):
        m = -1
        if i != 1:
            m = abs(w[i - 1].z - w[i - 2].z) / (w[i - 1].x - w[i - 2].x)
        
        m = max(m, abs(w[i].z - w[i - 1].z) / (w[i].x - w[i - 1].x))
        
        if i != k:
            m = max(m, abs(w[i + 1].z - w[i].z) / (w[i + 1].x - w[i].x))
        lam[i] = m
    lmax1 = lmax if abs(lmax) > 1e-8 else 1e-8
    # Сбор данных для нейронной сети
    for i in range(1, k + 1):
        xMin, k1 = simpleMinFunc(f, w[i - 1].x, w[i].x, EPS * 1e-2)
        mu_true = (w[i].z + w[i - 1].z - 2 * f(xMin)) / ((w[i].x - w[i - 1].x))
        #if abs(mu1) > 1 and i == 3 and k == 3:
        #    print(f"\tDebug: i={i}, k={k}, mu1={mu1}, lmax={lmax}, p={p}, w={w}")
        df.append({"x1" : lam[i - 1]/lmax1 if i != 1 else 0,
                   "x2" : lam[i]/lmax1,
                   "x3" : lam[i + 1]/lmax1 if i != k else 0,
                   "x4" : (w[i - 1].x - w[i - 2].x)/(b - a) if i != 1 else 0,
                   "x5" : (w[i].x - w[i - 1].x)/(b - a),
                   "x6" : (w[i + 1].x - w[i].x)/(b - a) if i != k else 0,
                   "y" : mu_true / lmax if mu_true < lmax else 1})
        #print(f"\t\t{i}")
    #print(f"\t{k}")
    

    for i in range(1, k + 1):
        H = max(lam[i], gamma[i], KSI)
        mu[i] = r * H

def step2_3(w, k, mu):
    t = -1
    Rmin = 0
    for i in range(1, k + 1):
        R = (w[i].z + w[i - 1].z)/2 - mu[i]*(w[i].x - w[i - 1].x)/2
        if t == -1 or R < Rmin:
            t = i
            Rmin = R
    return t
    
def argminf(w, k):
    imin = 0
    for i in range(0, k + 1):
        if w[i].z < w[imin].z:
            imin = i
    return imin

def collect(f, a, b, EPS, KSI, r, df):
    #Константа, число заведомо большее b, b << INF
    INF = 1000000000000.0

    # пары (x_i, z_i=f(x_i))
    w = [Point(INF, INF)] * 2
    mu = [INF] * 2

    #Шаг 0
    w[0] = Point(a, f(a))
    w[1] = Point(b, f(b))
    k = 1
    while True:
        #Шаг 1
        step1(w, k, KSI, r, mu, df, EPS, f, a, b)

        #Шаг 2, 3
        t = step2_3(w, k, mu)
    
        # Шаг 4
        if k == 10000 or w[t].x - w[t - 1].x <= EPS:
            imin = argminf(w, k)
            return (w[imin].x, w[imin].z, k)
    
        #Шаг 5
        x_next = (w[t].x + w[t - 1].x)/2 - (w[t].z - w[t - 1].z)/(2*mu[t])
        
        #Вставка новой точки и перенумерация x_i
        bi.insort(w, Point(x_next, f(x_next)))
        mu.append(INF)
        print(k)
        k += 1

def randomDistribution(a, b, n, mu):
    # Равномерное распределение
    #return np.random.uniform(a, b, n)

    # нормальное распределение с изменяемым мат. ожиданием
    
    numA = np.zeros(n)
    sigma = (b - a) / 4
    for i in range(n):
        t = rn.normalvariate(mu, sigma)
        while a >= t or t >= b:
            t = rn.normalvariate(mu, sigma)
        numA[i] = t
    return numA
    

def randomGenerate(f, a, b, EPS, df, epochs = 100, kMax = 200):
    for ep in range(epochs):
        k = rn.randint(1, kMax)
        w = [Point(0.1, 0.1)] * (k + 1)
        w[0] = Point(a, f(a))
        w[k] = Point(b, f(b))
        numA = randomDistribution(a, b, k + 1, rn.uniform(a, b))
        lam = [0.1]*(k + 1)
        for i in range(1, k):
            w[i] = Point(numA[i], f(numA[i]))

        w.sort()

        # X^max = max{x_i - x_i-1}
        Xmax = -1
        for i in range(1, k + 1):
            if w[i].x - w[i - 1].x > Xmax:
                Xmax = w[i].x - w[i - 1].x
    
        # lambda^max = max|z_i - z_i-1|/(x_i - x_i-1)
        lmax = -1
        for i in range(1, k + 1):
            cur = abs(w[i].z - w[i - 1].z) / (w[i].x - w[i - 1].x)
            if cur > lmax:
                lmax = cur
        # lambda_i = |z_i - z_i-1|/(x_i - x_i-1)
        for i in range(1, k + 1):
            lam[i] = abs(w[i].z - w[i - 1].z) / (w[i].x - w[i - 1].x)
        lmax1 = lmax if abs(lmax) > 1e-8 else 1e-8
        # Сбор данных для нейронной сети
        for i in range(1, k + 1):
            #xMin, k1 = simpleMinFunc(f, w[i - 1].x, w[i].x, EPS * 1e-2)
            #mu_true = (w[i].z + w[i - 1].z - 2 * f(xMin)) / ((w[i].x - w[i - 1].x))
            mu_true = max((lam[i - 1] if i != 1 else 0), lam[i], (lam[i + 1] if i != k else 0))
            #if abs(mu1) > 1 and i == 3 and k == 3:
            #    print(f"\tDebug: i={i}, k={k}, mu1={mu1}, lmax={lmax}, p={p}, w={w}")
            df.append({"x1" : lam[i - 1]/lmax1 if i != 1 else 0,
                    "x2" : lam[i]/lmax1,
                   "x3" : lam[i + 1]/lmax1 if i != k else 0,
                   "x4" : (w[i - 1].x - w[i - 2].x)/(b - a) if i != 1 else 0,
                   "x5" : (w[i].x - w[i - 1].x)/(b - a),
                   "x6" : (w[i + 1].x - w[i].x)/(b - a) if i != k else 0,
                   #"x7" : (w[i - 1].x - w[i - 2].x)/Xmax if i != 1 else 0,
                   #"x8" : (w[i].x - w[i - 1].x)/Xmax,
                   #"x9" : (w[i + 1].x - w[i].x)/Xmax if i != k else 0,
                   "y" : mu_true / lmax1 if mu_true < lmax else 1})
        print(ep + 1)

# Сбор датасета с помощью алгоритма НЛ

df = []
#with open("output1.txt", "w") as fout:
n = 10
for i in range(n):
    f = func[i][0]
    a = func[i][1]
    b = func[i][2]
    x_min, f_min, k = collect(f, a, b, 1e-4*(b - a), 1e-6, 1.1, df)
    print(f"{i + 1}/10")
    #fout.write(f"{i + 1}\t{k + 1}\tminf({x_min})={f_min}\n")
df1 = pd.DataFrame(df, columns=["x1", "x2", "x3", "x4", "x5", "x6", "y"])
df1.to_excel("/content/drive/MyDrive/Диплом/dataSet1_ba.xlsx", index=False)

# Сбор датасета на случайных точках

df = []
#with open("output1.txt", "w") as fout:
for j in [1,2,4,7,8,9,10,11,12,13,14,16,17,18,19,20]:
    i = j - 1
    f = func[i][0]
    a = func[i][1]
    b = func[i][2]
    randomGenerate(f, a, b, 1e-4*(b - a), df, 10)
    print(f"F №{j}")
    #fout.write(f"{i + 1}\t{k + 1}\tminf({x_min})={f_min}\n")
#print(df)
df1 = pd.DataFrame(df, columns=["x1", "x2", "x3", "x4", "x5", "x6", "y"])
df1.to_excel("/content/drive/MyDrive/Диплом/dataSets/Lmax/test.xlsx", index=False)