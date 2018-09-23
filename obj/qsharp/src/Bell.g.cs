#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Bell", "Set (desired : Result, q1 : Qubit) : ()", new string[] { }, "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs", 236L, 6L, 53L)]
[assembly: OperationDeclaration("Bell", "BellTest (count : Int, initial : Result) : (Int, Int, Int)", new string[] { }, "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs", 556L, 16L, 72L)]
#line hidden
namespace Bell
{
    public class Set : Operation<(Result,Qubit), QVoid>, ICallable
    {
        public Set(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Result,Qubit)>, IApplyData
        {
            public In((Result,Qubit) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits
            {
                get
                {
                    yield return Data.Item2;
                }
            }
        }

        String ICallable.Name => "Set";
        String ICallable.FullName => "Bell.Set";
        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        public override Func<(Result,Qubit), QVoid> Body => (__in) =>
        {
            var (desired,q1) = __in;
#line 8 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
            var current = M.Apply(q1);
            // immutable
            // sets a qubit in a known state (0 or 1)
#line 10 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
            if ((desired != current))
            {
#line 11 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
                MicrosoftQuantumPrimitiveX.Apply(q1);
                // flip the state with the X gate
                ;
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
        }

        public override IApplyData __dataIn((Result,Qubit) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Result desired, Qubit q1)
        {
            return __m__.Run<Set, (Result,Qubit), QVoid>((desired, q1));
        }
    }

    public class BellTest : Operation<(Int64,Result), (Int64,Int64,Int64)>, ICallable
    {
        public BellTest(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Result)>, IApplyData
        {
            public In((Int64,Result) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        public class Out : QTuple<(Int64,Int64,Int64)>, IApplyData
        {
            public Out((Int64,Int64,Int64) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "BellTest";
        String ICallable.FullName => "Bell.BellTest";
        protected Allocate Allocate
        {
            get;
            set;
        }

        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumPrimitiveCNOT
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected ICallable<(Result,Qubit), QVoid> Set
        {
            get;
            set;
        }

        public override Func<(Int64,Result), (Int64,Int64,Int64)> Body => (__in) =>
        {
            var (count,initial) = __in;
#line 18 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
            var numOnes = 0L;
            // can be changed using set statement
#line 19 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
            var agree = 0L;
#line 20 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
            var qubits = Allocate.Apply(2L);
#line 21 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
            foreach (var test in new Range(1L, count))
            {
#line 22 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
                Set.Apply((initial, qubits[0L]));
#line 23 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
                Set.Apply((Result.Zero, qubits[1L]));
                // Hadamard gate which flips a qubit only halfway.
#line 26 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
                MicrosoftQuantumPrimitiveH.Apply(qubits[0L]);
#line 27 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
                MicrosoftQuantumPrimitiveCNOT.Apply((qubits[0L], qubits[1L]));
#line 28 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
                var res = M.Apply(qubits[0L]);
#line 30 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
                if ((M.Apply(qubits[1L]) == res))
                {
#line 31 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
                    agree = (agree + 1L);
                }

                // Count the number of ones we saw:
#line 35 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
                if ((res == Result.One))
                {
#line 36 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
                    numOnes = (numOnes + 1L);
                }
            }

#line 39 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
            Set.Apply((Result.Zero, qubits[0L]));
#line 40 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
            Set.Apply((Result.Zero, qubits[1L]));
#line hidden
            Release.Apply(qubits);
            // Return number of times we saw a |0> and number of times we saw a |1>
#line 43 "/Users/kaseystowell/Documents/workspace/quantum/Bell/Bell.qs"
            return ((count - numOnes), numOnes, agree);
        }

        ;
        public override void Init()
        {
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumPrimitiveCNOT = this.Factory.Get<IUnitary<(Qubit,Qubit)>>(typeof(Microsoft.Quantum.Primitive.CNOT));
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.Set = this.Factory.Get<ICallable<(Result,Qubit), QVoid>>(typeof(Bell.Set));
        }

        public override IApplyData __dataIn((Int64,Result) data) => new In(data);
        public override IApplyData __dataOut((Int64,Int64,Int64) data) => new Out(data);
        public static System.Threading.Tasks.Task<(Int64,Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<BellTest, (Int64,Result), (Int64,Int64,Int64)>((count, initial));
        }
    }
}