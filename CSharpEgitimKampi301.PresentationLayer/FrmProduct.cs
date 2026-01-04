using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        ProductManager ProductManager = new ProductManager(new EfProductDal());

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue.ToString());
            product.ProductPrice = Convert.ToDecimal(txtProductPrice.Text);
            product.ProductName = txtProductName.Text;
            product.ProductDescription = txtProductDescription.Text;
            product.ProductStock = Convert.ToInt32(textProductStock.Text);
            _productService.TInsert(product);
            MessageBox.Show("Ürün Eklendi");
        }

        private void textProductStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            MessageBox.Show("Ürün Silindi");
        }

        private void btnId_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            txtProductName.Text = value.ProductName;
            textProductStock.Text = value.ProductStock.ToString();
            txtProductPrice.Text = value.ProductPrice.ToString();
            txtProductDescription.Text = value.ProductDescription;
            dataGridView1.DataSource = value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            value.CategoryID = int.Parse(cmbCategory.SelectedValue.ToString());
            value.ProductName = txtProductName.Text;
            value.ProductStock = Convert.ToInt32(textProductStock.Text);
            value.ProductPrice = Convert.ToDecimal(txtProductPrice.Text);
            value.ProductDescription = txtProductDescription.Text;
            _productService.TUpdate(value);
            MessageBox.Show("Ürün Güncellendi");
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            cmbCategory.DataSource = values;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.SelectedIndex = 0;
        }
    }
}
