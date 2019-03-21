using algebra_de_conjuntos.Actions;
using algebra_de_conjuntos.Models;
using algebra_de_conjuntos.utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace algebra_de_conjuntos
{
    public partial class MainWindow : Window
    {

        public List<Set> ListaConjuntos { get; set; }
        public List<Element> ListaElementos { get; set; }
        private ObservableCollection<SetOrElementDisplayable> Lista { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ListaConjuntos = new List<Set>();
            ListaElementos = new List<Element>();
            Lista = new ObservableCollection<SetOrElementDisplayable>();
            lstNomes.ItemsSource = Lista;
            comboBoxA.ItemsSource = Lista;
            comboBoxB.ItemsSource = Lista;

        }

        private void AtualizaLista()
        {
            foreach (Set c in ListaConjuntos)
            {
                if (!Lista.ToList<SetOrElementDisplayable>().Exists(x => x.Id == c.Id))
                {
                    Lista.Add(
                     new SetOrElementDisplayable
                     {
                         Id = c.Id,
                         Name = c.Name,
                         Value = c.ElementsSetToString()
                     });
                }

            }

            foreach (Element e in ListaElementos)
            {
                if (!Lista.ToList<SetOrElementDisplayable>().Exists(x => x.Id == e.Id))
                {
                    Lista.Add(
                    new SetOrElementDisplayable
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Value = e.Value
                    });
                }
            }
        }

        private bool IsSelecionado()
        {
            btnReverterPA.Visibility = Visibility.Hidden;
            btnReverterCart.Visibility = Visibility.Hidden;

            if (comboBoxA.SelectedValue != null && comboBoxB.SelectedValue != null)
            {
                return true;
            }
            else
            {
                txtSaida.Text = $"É necessário selecionar ambos ComboBoxes antes de realizar uma operação";
                return false;
            }
        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string[] content;
                content = File.ReadAllLines(openFileDialog.FileName);
                StringToModel conversor = new StringToModel();
                List<string> newContent = new List<string>();

                foreach (string line in content)
                {
                    if (line != null)
                    {
                        if (!line.Equals(""))
                        {
                            if (!line[0].Equals('#'))
                            {
                                newContent.Add(line);
                            }
                        }
                    }
                }

                conversor.Load(newContent);

                foreach (Set c in conversor.Sets)
                {
                    ListaConjuntos.Add(c);
                }

                foreach (Element el in conversor.Elements)
                {
                    ListaElementos.Add(el);
                }

                AtualizaLista();
            }
        }

        private Set GetConjuntoByID(string id)
        {
            foreach (Set c in ListaConjuntos)
            {
                if (c.Id.ToString().Equals(id))
                {
                    return c;
                }
            }
            return null;
        }

        private Element GetElementoByID(string id)
        {
            foreach (Element e in ListaElementos)
            {
                if (e.Id.ToString().Equals(id))
                {
                    return e;
                }
            }
            return null;
        }


        private void BtnPertence_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelecionado())
            {
                Element elementoA = GetElementoByID(comboBoxA.SelectedValue.ToString());
                Set conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (elementoA != null && conjuntoB != null)
                {
                    resultado = Operator.Belongs(elementoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";

                    txtSaida.Text = $"O elemento {elementoA.Value} {resultadoTxt} pertence ao conjunto {conjuntoB.Name}";
                }
                else
                {
                    txtSaida.Text = $"A operação de pertence só pode ser realizada entre um elemento e um conjunto, na ordem";
                }
            }
        }

        private void BtnNaoPertence_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelecionado())
            {
                Element elementoA = GetElementoByID(comboBoxA.SelectedValue.ToString());
                Set conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (elementoA != null && conjuntoB != null)
                {
                    resultado = Operator.Belongs(elementoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";

                    txtSaida.Text = $"O elemento {elementoA.Value} {resultadoTxt} pertence ao conjunto {conjuntoB.Name}";
                }
                else
                {
                    txtSaida.Text = $"A operação de não pertence só pode ser realizada entre um elemento e um conjunto, na ordem";
                }
            }
        }

        private void BtnContidoPropriamente_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelecionado())
            {
                Set conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Set conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operator.ProperlyContain(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Name} {resultadoTxt} está propriamente contido no {conjuntoB.Name}";

                }

                else
                {
                    txtSaida.Text = $"A operação de Contido Propriamente só pode ser realizada entre conjuntos";
                }
            }

        }

        private void BtnNaoContidoPropriamente_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelecionado())
            {
                Set conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Set conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operator.ProperlyContain(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Name} {resultadoTxt} está propriamente contido no {conjuntoB.Name}";

                }

                else
                {
                    txtSaida.Text = $"A operação de Não Contido Propriamente só pode ser realizada entre conjuntos";
                }
            }

        }

        private void BtnContidoOuIgual_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelecionado())
            {
                Set conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Set conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operator.Contain(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Name} {resultadoTxt} está contido ou igual ao  {conjuntoB.Name}";
                }

                else
                {
                    txtSaida.Text = $"A operação de Contido ou igual só pode ser realizada entre conjuntos";
                }
            }

        }

        private void BtnNaoContidoOuIgual_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelecionado())
            {
                Set conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Set conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operator.ProperlyContain(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Name} {resultadoTxt} está contido ou igual ao  {conjuntoB.Name}";

                }

                else
                {
                    txtSaida.Text = $"A operação de Não Contido ou igual só pode ser realizada entre conjuntos";
                }
            }
        }

        private void BtnUniao_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelecionado())
            {
                Set conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Set conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());

                if (conjuntoA != null && conjuntoB != null)
                {
                    Set novoConjunto = Operator.Union(conjuntoA, conjuntoB);
                    txtSaida.Text = novoConjunto.ToString();

                    ListaConjuntos.Add(novoConjunto);
                    AtualizaLista();
                }
                else
                {
                    txtSaida.Text = $"A operação de União só pode ser realizada entre conjuntos";
                }
            }
        }

        private void BtnIntersecao_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelecionado())
            {
                Set conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Set conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());

                if (conjuntoA != null && conjuntoB != null)
                {
                    Set novoConjunto = Operator.Intersection(conjuntoA, conjuntoB);
                    txtSaida.Text = novoConjunto.ToString();

                    ListaConjuntos.Add(novoConjunto);
                    AtualizaLista();
                }
                else
                {
                    txtSaida.Text = $"A operação de Interseção só pode ser realizada entre conjuntos";
                }
            }
        }

        private void BtnProdutoCartesiano_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelecionado())
            {
                Set conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Set conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());

                if (conjuntoA != null && conjuntoB != null)
                {
                    Set novoConjunto = Operator.CartesianProduct(conjuntoA, conjuntoB);
                    txtSaida.Text = novoConjunto.ToString();

                    ListaConjuntos.Add(novoConjunto);
                    AtualizaLista();
                    btnReverterCart.Visibility = Visibility.Visible;
                }
                else
                {
                    txtSaida.Text = $"A operação de Produto Cartesiano só pode ser realizada entre conjuntos";
                }
            }
        }

        private void BtnConjuntoDasPartes_Click(object sender, RoutedEventArgs e)
        {

            if (comboBoxA.SelectedValue != null && GetConjuntoByID(comboBoxA.SelectedValue.ToString()) != null)
            {
                Set conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());

                Set novoConjunto = Operator.SetOfParts(conjuntoA);
                txtSaida.Text = novoConjunto.ToString();

                ListaConjuntos.Add(novoConjunto);
                AtualizaLista();
                btnReverterPA.Visibility = Visibility.Visible;

            }
            else
            {
                txtSaida.Text = $"Para essa operação o primeiro ComboBox precisa selecionar um conjunto";
            }

        }

        private void BtnContem_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelecionado())
            {
                Set conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Set conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operator.Contains(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Name} {resultadoTxt} contém {conjuntoB.Name}";
                }
                else
                {
                    txtSaida.Text = $"A operação de Contém só pode ser realizada entre conjuntos";
                }
            }
        }

        private void BtnNaoContem_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelecionado())
            {
                Set conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Set conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operator.Contains(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Name} {resultadoTxt} contém {conjuntoB.Name}";
                }
                else
                {
                    txtSaida.Text = $"A operação de Não Contém só pode ser realizada entre conjuntos";
                }
            }
        }

        private void ButtonReverterCartesiano_Click(object sender, RoutedEventArgs e)
        {
            Tuple<Set, Set> tupla = OperatorReverse.ReversivelProdutoCartesiano(ListaConjuntos[ListaConjuntos.Count - 1]);
            txtSaida.Text = $"{tupla.Item1.ToString()} \n {tupla.Item2.ToString()}";
            btnReverterCart.Visibility = Visibility.Hidden;
        }

        private void ButtonReverterPA_Click(object sender, RoutedEventArgs e)
        {
            Set c = OperatorReverse.ReversivelProdutoDasPartes(ListaConjuntos[ListaConjuntos.Count - 1]);
            txtSaida.Text = $"{c.ToString()}";
            btnReverterPA.Visibility = Visibility.Hidden;
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            ListaConjuntos = new List<Set>();
            ListaElementos = new List<Element>();
            Lista = new ObservableCollection<SetOrElementDisplayable>();
            lstNomes.ItemsSource = Lista;
            comboBoxA.ItemsSource = Lista;
            comboBoxB.ItemsSource = Lista;
            btnReverterPA.Visibility = Visibility.Hidden;
            btnReverterCart.Visibility = Visibility.Hidden;
            txtSaida.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wrapAlgebra.Visibility = Visibility.Visible;
            wrapBtnAlgebra.Visibility = Visibility.Visible;
        }
    }
}

