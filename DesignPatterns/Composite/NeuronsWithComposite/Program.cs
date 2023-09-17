using System.Collections;
using System.Collections.ObjectModel;

var n1 = new Neuron();
var n2 = new Neuron();
n1.ConnectTo(n2);

var l1 = new NeuronLayer();
var l2 = new NeuronLayer();

n1.ConnectTo(l1);
l1.ConnectTo(l2);

public static class ExtensionMethods
{
    public static void ConnectTo(this IEnumerable<Neuron> selfList, IEnumerable<Neuron> otherList)
    {
        if (ReferenceEquals(selfList, otherList))
            return;

        foreach (var selfNeuron in selfList)
        {
            foreach (var otherNeuron in otherList)
            {
                selfNeuron.ConnectTo(otherNeuron);
            }
        }
    }
}

public class Neuron : IEnumerable<Neuron>
{
    public float Value;

    public List<Neuron> In, Out;

    public void ConnectTo(Neuron other)
    {
        Out.Add(other);
        other.In.Add(this);
    }

    public IEnumerator<Neuron> GetEnumerator()
    {
        yield return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class NeuronLayer : Collection<Neuron>
{
    
}
