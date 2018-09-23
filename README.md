# bell-state
My first quantum algorithm that creates a Bell State showing entanglement using Quantum Computing and Microsofts Q# language.

### Initial State
```
Init:Zero 0s=1000 1s=0
Init:One  0s=0    1s=1000
```

### X Gate Flipped State
```
Init:Zero 0s=0    1s=1000
Init:One  0s=1000 1s=0
```

### Hamilton Gate Superposition Half Flipped State
#### Run 1
```
Init:Zero 0s=490  1s=510
Init:One  0s=507  1s=493
```
#### Run 2
```
Init:Zero 0s=466  1s=534
Init:One  0s=492  1s=508
```

### Two Qubits w/CNOT
```
Init:Zero 0s=525  1s=475
Init:One  0s=553  1s=447
```

### Quantum Entangelemnt
```
Init:Zero 0s=502  1s=498  agree=1000
Init:One  0s=474  1s=526  agree=1000
```
The first qubit statistics are 50/50 but the second qubit is always the **same** as the first. They are entangled. Whatever happens to the first qubit will happen to the second.
