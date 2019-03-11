using algebra_de_conjuntos.Models;
using algebra_de_conjuntos.utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace algebra_de_conjuntos
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Conjunto> ListaConjuntos { get; set; }
        public List<Elemento> ListaElementos { get; set; }
        private ObservableCollection<ConjuntoOrElementDisplayable> Lista { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ListaConjuntos = new List<Conjunto>();
            ListaElementos = new List<Elemento>();
            Lista = new ObservableCollection<ConjuntoOrElementDisplayable>();
            lstNomes.ItemsSource = Lista;
            comboBoxA.ItemsSource = Lista;
            comboBoxB.ItemsSource = Lista;

        }

        private void AtualizaLista()
        {
            foreach (Conjunto c in ListaConjuntos)
            {
                if (!Lista.ToList<ConjuntoOrElementDisplayable>().Exists(x => x.Id == c.Id))
                {
                    Lista.Add(
                     new ConjuntoOrElementDisplayable
                     {
                         Id = c.Id,
                         Nome = c.Nome,
                         Valor = c.ElementosConjuntoToString()
                     });
                }

            }

            foreach (Elemento e in ListaElementos)
            {
                if (!Lista.ToList<ConjuntoOrElementDisplayable>().Exists(x => x.Id == e.Id))
                {
                    Lista.Add(
                    new ConjuntoOrElementDisplayable
                    {
                        Id = e.Id,
                        Nome = e.Nome,
                        Valor = e.Valor
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

                foreach (Conjunto c in conversor.Conjuntos)
                {
                    ListaConjuntos.Add(c);
                }

                foreach (Elemento el in conversor.Elementos)
                {
                    ListaElementos.Add(el);
                }

                AtualizaLista();
            }
        }

        private Conjunto GetConjuntoByID(string id)
        {
            foreach (Conjunto c in ListaConjuntos)
            {
                if (c.Id.ToString().Equals(id))
                {
                    return c;
                }
            }
            return null;
        }

        private Elemento GetElementoByID(string id)
        {
            foreach (Elemento e in ListaElementos)
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
                Elemento elementoA = GetElementoByID(comboBoxA.SelectedValue.ToString());
                Conjunto conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (elementoA != null && conjuntoB != null)
                {
                    resultado = Operador.Pertence(elementoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";

                    txtSaida.Text = $"O elemento {elementoA.Valor} {resultadoTxt} pertence ao conjunto {conjuntoB.Nome}";
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
                Elemento elementoA = GetElementoByID(comboBoxA.SelectedValue.ToString());
                Conjunto conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (elementoA != null && conjuntoB != null)
                {
                    resultado = Operador.Pertence(elementoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";

                    txtSaida.Text = $"O elemento {elementoA.Valor} {resultadoTxt} pertence ao conjunto {conjuntoB.Nome}";
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
                Conjunto conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Conjunto conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operador.ContidoPropriamente(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Nome} {resultadoTxt} está propriamente contido no {conjuntoB.Nome}";

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
                Conjunto conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Conjunto conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operador.ContidoPropriamente(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Nome} {resultadoTxt} está propriamente contido no {conjuntoB.Nome}";

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
                Conjunto conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Conjunto conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operador.Contido(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Nome} {resultadoTxt} está contido ou igual ao  {conjuntoB.Nome}";
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
                Conjunto conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Conjunto conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operador.ContidoPropriamente(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Nome} {resultadoTxt} está contido ou igual ao  {conjuntoB.Nome}";

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
                Conjunto conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Conjunto conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());

                if (conjuntoA != null && conjuntoB != null)
                {
                    Conjunto novoConjunto = Operador.Uniao(conjuntoA, conjuntoB);
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
                Conjunto conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Conjunto conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());

                if (conjuntoA != null && conjuntoB != null)
                {
                    Conjunto novoConjunto = Operador.Intersecao(conjuntoA, conjuntoB);
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
                Conjunto conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Conjunto conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());

                if (conjuntoA != null && conjuntoB != null)
                {
                    Conjunto novoConjunto = Operador.ProdutoCartesiano(conjuntoA, conjuntoB);
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
                Conjunto conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());

                Conjunto novoConjunto = Operador.ConjuntoDasPartes(conjuntoA);
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
                Conjunto conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Conjunto conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operador.Contem(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Nome} {resultadoTxt} contém {conjuntoB.Nome}";
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
                Conjunto conjuntoA = GetConjuntoByID(comboBoxA.SelectedValue.ToString());
                Conjunto conjuntoB = GetConjuntoByID(comboBoxB.SelectedValue.ToString());
                bool resultado;

                if (conjuntoA != null && conjuntoB != null)
                {
                    resultado = Operador.Contem(conjuntoA, conjuntoB);
                    string resultadoTxt = resultado ? "" : "não";
                    txtSaida.Text = $"O conjunto {conjuntoA.Nome} {resultadoTxt} contém {conjuntoB.Nome}";
                }
                else
                {
                    txtSaida.Text = $"A operação de Não Contém só pode ser realizada entre conjuntos";
                }
            }
        }

        private void ButtonReverterCartesiano_Click(object sender, RoutedEventArgs e)
        {
            Tuple<Conjunto, Conjunto> tupla = Operador.ReversivelProdutoCartesiano(ListaConjuntos[ListaConjuntos.Count - 1]);
            txtSaida.Text = $"{tupla.Item1.ToString()} \n {tupla.Item2.ToString()}";
            btnReverterCart.Visibility = Visibility.Hidden;
        }

        private void ButtonReverterPA_Click(object sender, RoutedEventArgs e)
        {
            Conjunto c = Operador.ReversivelProdutoDasPartes(ListaConjuntos[ListaConjuntos.Count - 1]);
            txtSaida.Text = $"{c.ToString()}";
            btnReverterPA.Visibility = Visibility.Hidden;
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            ListaConjuntos = new List<Conjunto>();
            ListaElementos = new List<Elemento>();
            Lista = new ObservableCollection<ConjuntoOrElementDisplayable>();
            lstNomes.ItemsSource = Lista;
            comboBoxA.ItemsSource = Lista;
            comboBoxB.ItemsSource = Lista;
            btnReverterPA.Visibility = Visibility.Hidden;
            btnReverterCart.Visibility = Visibility.Hidden;
            txtSaida.Text = "";
        }

        
    }
}

