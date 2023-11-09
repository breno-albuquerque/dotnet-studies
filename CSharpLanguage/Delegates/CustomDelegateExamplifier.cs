//  Para Estudos: Leitura sequencial (Cima para Baixo) 
namespace Delegates
{
    //  Declarando novos Delegates
    public delegate void CustomDelegate1<in T1, in T2>(T1 param1, T2 param2);

    //  PS: Um delegate que retorna bool poderia ser substituído pelo Predicate (Um delegate já existente no .NET)
    public delegate bool CustomDelegate2<in T1>(T1 param1);

    public class CustomDelegateExamplifier
    {
        private List<int> _list = new() { 1, 2, -1, -2 };

        //  Novo método com a assinatura do CustomDelegate
        private void CustomDelegateMethod(int param1, int param2)
        {
            Console.WriteLine($"Executando CustomDelegateMethod. Parâmetros: {param1}, {param2}");
        }

        //  Criando variável do tipo CustomDelegate e atribuindo ao método CustomDelegateMethod
        public void ExecuteExample_1()
        {
            CustomDelegate1<int, int> customDelegate1 = CustomDelegateMethod;

            customDelegate1.Invoke(1, 1);
            customDelegate1(2, 2);
        }

        // Utilizando lambda expressions para atribuir ao tipo CustomDelegate
        public void ExecuteExample_2()
        {
            CustomDelegate1<int, int> customDelegate1 = (int param1, int param2) =>
            {
                Console.WriteLine($"Executando lambda expression. Parâmetros: {param1}, {param2}");
            };

            customDelegate1.Invoke(1, 1);
            customDelegate1(2, 2);
        }

        //  Método que aceita um CustomDelegate como parâmetro
        public void ExecuteExample_3(CustomDelegate2<int> removeFromListCriterion)
        {
            Console.WriteLine($"Quantidade de elementos antes: {_list.Count}");
            
            var result = new List<int>();

            foreach (var number in _list)
            {
                if (removeFromListCriterion(number) == false)
                    result.Add(number);
            }

            _list = result;
            
            Console.WriteLine($"Quantidade de elementos depois: {_list.Count}");
        }
    }
}