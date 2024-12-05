import math


inputValid = False
while not inputValid:
    try:
        x=float(input("What Number?\n"))
        inputValid = True
    except ValueError:
        print("Not a float")
        inputValid = False

if (x>=100) and (x<=9223372036854775807):
    t = 2
    print("Preforming Preliminary Check...")
    stop = False
    while (t<=100) and not stop:
        if(x%t!=0):
            t = t+1
        else:
            print(x, " is not prime! - it is divisible by ", t)
            stop = True
            exit()
    print("Finding Possible Prime Factors...")
    y=[2,3]
    z=4
    w=2
    prime = True
    stop = False
    while z<=math.sqrt(x):
        w = 2
        prime = True
        stop = False
        while w<=math.sqrt(z) and not stop and prime:
            if (z%w==0):
                prime = False
            elif (w+1)>=math.sqrt(z) and prime:
                y.append(z)
                #print(z)
                stop = True
                break
            w=w+1
        z=z+1
    prime = True
    print("Checking if it is prime...")
    for prime_candidate in y:
        if x % prime_candidate == 0:
            print(f"{x} is not prime! - it is divisible by {prime_candidate}")
            prime = False
            break
    if prime:
        print(x, " is prime!")