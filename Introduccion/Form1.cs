namespace Introduccion;
using Figuras;
public partial class Form1 : Form
{
    private Label? lblFigura;
    private ComboBox? cmbFiguras;
    private Label? lblCalculo;
    private ComboBox? cmbCalculos;
    private Label[] lblIncognitas;
    private TextBox[] incognitas;
    private Label? lblResultado;
    private TextBox? txtResultado;
    private Button? btnCalcular;
    private Figura? figura;
       public Form1()
    {
        InitializeComponent();
        InicializarComponentes();
        
    }
    private void InicializarComponentes()
    {
        // Tamaño de la ventana
        this.Size = new Size(300,350);

        //Etiqueta Figura
        lblFigura= new Label();
        lblFigura.Text="Figura";
        lblFigura.AutoSize=true;
        lblFigura.Location= new Point(10,10);

        //ComboBox Figuras
        cmbFiguras = new ComboBox();
        cmbFiguras.Items.Add("Selecciona figura");
        cmbFiguras.Items.Add("Cuadrado");
        cmbFiguras.Items.Add("Rectangulo");
        cmbFiguras.Items.Add("Triangulo");
        cmbFiguras.SelectedIndex=0;
        cmbFiguras.Location= new Point(10,40);
        cmbFiguras.SelectedValueChanged+=new EventHandler(cmb_ValueChanged);

        //Etiqueta Calculo
        lblCalculo= new Label();
        lblCalculo.Text="Cálculo";
        lblCalculo.AutoSize=true;
        lblCalculo.Location= new Point(150,10);

        //ComboBox Calculos
        cmbCalculos = new ComboBox();
        cmbCalculos.Items.Add("Selecciona calculo");
        cmbCalculos.Items.Add("Périmetro");
        cmbCalculos.Items.Add("Área");
        cmbCalculos.SelectedIndex=0;
        cmbCalculos.Location= new Point(150,40);
        cmbCalculos.SelectedValueChanged+=new EventHandler(cmb_ValueChanged);
        incognitas = new TextBox[5];
        lblIncognitas = new Label[5];
        for (int i = 0; i < incognitas.Length; i++)
        {
            //Etiqueta incognita
            Label lblAltura = new Label();
            lblAltura.Text = $"lado {i}";
            lblAltura.AutoSize = true;
            lblAltura.Location = new Point(10, 80 +(20*i));
            lblAltura.Visible = false;

            //TextBox incognita
            TextBox txtAltura = new TextBox();
            txtAltura.Size = new Size(100, 20);
            txtAltura.Location = new Point(60, 75+(20*i));
            txtAltura.Visible = false;

            lblIncognitas[i] = lblAltura;
            incognitas[i] = txtAltura;
        }

       

        //Etiqueta resul
        lblResultado = new Label();
        lblResultado.Text="Resultado";
        lblResultado.AutoSize=true;
        lblResultado.Location= new Point(10,280);

        //TextBox Prueba
        txtResultado=new TextBox();
        txtResultado.Size = new Size(100,20);
        txtResultado.Location= new Point(70,275);

        //Boton Calcular
        btnCalcular= new Button();
        btnCalcular.Text="Calcular";
        btnCalcular.AutoSize=true;
        btnCalcular.Location= new Point(200,200);
        btnCalcular.Click+= new EventHandler(btnCalcular_Click);

        //Agregar controles a la ventana
        this.Controls.Add(lblFigura);
        this.Controls.Add(cmbFiguras);
        this.Controls.Add(lblCalculo);
        this.Controls.Add(cmbCalculos);
        
        foreach(TextBox textBox in incognitas)
        {
            this.Controls.Add(textBox);
        }
        foreach(Label lbl in lblIncognitas)
        {
            this.Controls.Add(lbl);
        }
        this.Controls.Add(lblResultado);
        this.Controls.Add(txtResultado);
        this.Controls.Add(btnCalcular);

    }
    private void cmb_ValueChanged(object sender, EventArgs e){
        foreach (TextBox textBox in incognitas)
        {
            textBox.Visible = false;
        }
        foreach (Label lbl in lblIncognitas)
        {
            lbl.Visible = false;
        }
        if (cmbCalculos.SelectedIndex!=0 && cmbFiguras.SelectedIndex!=0){
            //figura = new Cuadrado();
            switch (cmbFiguras.SelectedItem.ToString())
            {
                case "Cuadrado": figura = new Cuadrado();
                    break;
                case "Rectangulo": figura = new Rectangulo();
                    break;
                case "Triangulo": figura=new Triangulo();
                    break;
                default: figura= null; break;


            }
                if(cmbCalculos.SelectedItem.ToString()=="Périmetro"){
                muestraCampos();
                }
                if(cmbCalculos.SelectedItem.ToString()=="Área"){
                muestraCampos();
                }
        }
    }


    private void muestraCampos()
    {
        if (figura == null) return;
        for (int i=0; i<figura.getIncognitas.Length; i++) {
            lblIncognitas[i].Text = figura.getIncognitas[i];
            lblIncognitas[i].Visible = true;
            incognitas[i].Visible = true;
        } 
    } 

    //metodo que regresa si los campos necesarios estan llenos y contienen numeros enteros solamente.
    private bool validaCampos()
    {
        for (int i = 0; i < figura.getIncognitas.Length; i++)
        {
            lblIncognitas[i].Text = figura.getIncognitas[i];
            incognitas[i].Visible = true;

            if (incognitas[i].Text != "")
            {
                    try
                    {
                        int altura = Convert.ToInt32(incognitas[i].Text);
                    }
                    catch (Exception) { return false; }
            }
            else
            {
                return false;
            }

        }
        return true;
    }

    //llamar solo si ya se comprobo el valor en todos los campos
    private int[] obtenValores()
    {
        int[] valores= new int[figura.getIncognitas.Length];
        for(int i=0; i < valores.Length; i++)
        {
            valores[i] = Convert.ToInt32(incognitas[i].Text);
        }
        return valores;
    }

    private void btnCalcular_Click(object sender, EventArgs e){
        string calculo= cmbCalculos.SelectedItem.ToString();
        if (figura!= null && validaCampos()) {
            double resul = -1;
            if(calculo=="Périmetro"){
                resul = figura.obtenPerimetro(obtenValores());
                //txtResultado.Text=(figura.obtenPerimetro(obtenValores())).ToString();
            }
            if(calculo=="Área"){
                resul =figura.obtenArea(obtenValores());
                //txtResultado.Text=(figura.obtenArea(obtenValores())).ToString();
            }
            if (resul < 0)
            {
                txtResultado.Text = "Proporciones invalidas.";
            }
            //pasa que le valores negativos o no es posible formar una figura con dichas longitudos para el triangulo. 
            else
            {
                txtResultado.Text = resul.ToString();
            }
        }
        else
        {
            txtResultado.Text = "NaN.";
        }
    }
    
}
