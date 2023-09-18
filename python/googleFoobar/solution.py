import math

def solution(inp):
    if (inp == 1):
        return [1]

    squares = [x*x for x in range(1,int(math.ceil(math.sqrt(inp))) + 1) if x * x <= inp]

    result = []
    start = len(squares) - 1
    for i in range(start, -1, -1):
        if (inp <= 0):
            break
        else:
            while (squares[i] <= inp):
                result.append(squares[i])
                inp -= squares[i]
    return result

print (solution(12))
