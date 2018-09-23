namespace Bell {
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Primitive;

    // the tuple contains the Q# arguments, the return type is specified after the colon
    operation Set (desired: Result, q1: Qubit) : () {
        body {
            let current = M(q1); // immutable
            // sets a qubit in a known state (0 or 1)
            if (desired != current) {
	           X(q1); // flip the state with the X gate
            }
        }
    }

    operation BellTest (count: Int, initial: Result) : (Int, Int, Int) {
        body {
            mutable numOnes = 0; // can be changed using set statement
            mutable agree = 0;
            using (qubits = Qubit[2]) { 
                for (test in 1..count) {
                    Set (initial, qubits[0]);
                    Set (Zero, qubits[1]);

                    // Hadamard gate which flips a qubit only halfway.
                    H(qubits[0]);
                    CNOT(qubits[0], qubits[1]);
                    let res = M (qubits[0]);

                    if (M (qubits[1]) == res) {
                        set agree = agree + 1;
                    }

                    // Count the number of ones we saw:
                    if (res == One) {
                        set numOnes = numOnes + 1;
                    }
                }
                Set(Zero, qubits[0]);
                Set(Zero, qubits[1]);
            }
            // Return number of times we saw a |0> and number of times we saw a |1>
            return (count - numOnes, numOnes, agree);
        }
    }
}
