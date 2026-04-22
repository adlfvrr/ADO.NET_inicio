using DAO_proy.DTOs;
using DAO_proy.entity;
using DAO_proy.service;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModalProductos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lvwInicializar();
            this.service = new PhoneService();
        }

        PhoneService service;

        #region lvw redibujado
        public void lvwInicializar()
        {
            lvwCelulares.View = View.Tile;
            lvwCelulares.FullRowSelect = true;
            lvwCelulares.HideSelection = false;
            lvwCelulares.OwnerDraw = true;
            lvwCelulares.TileSize = new Size(300, 100);
            lvwCelulares.BackColor = Color.WhiteSmoke;
            lvwCelulares.BorderStyle = BorderStyle.None;
            lvwCelulares.DrawItem += lvwCelulares_DrawItem;
            lvwCelulares.SelectedIndexChanged += lvwCelulares_SelectedIndexChanged;
        }
        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arc, 180, 90);

            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        private void lvwCelulares_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var rect = e.Bounds;

            Color backColor = e.Item.Selected ? Color.LightBlue : Color.White;
            Color borderColor = e.Item.Selected ? Color.DodgerBlue : Color.LightGray;

            using (var brush = new SolidBrush(backColor))
            using (var pen = new Pen(borderColor, 2))
            {
                int radius = 10;
                var path = RoundedRect(rect, radius);
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
            }

            string text = e.Item.Text;
            var fontTitle = new Font("Segoe UI", 8, FontStyle.Bold);
            var fontSub = new Font("Segoe UI", 7, FontStyle.Regular);

            e.Graphics.DrawString(text, fontTitle, Brushes.Black, rect.X + 10, rect.Y + 10);

            int offsetY = 30;
            foreach (ListViewItem.ListViewSubItem sub in e.Item.SubItems)
            {
                if (sub == e.Item.SubItems[0]) continue;
                e.Graphics.DrawString(sub.Text, fontSub, Brushes.DimGray, rect.X + 10, rect.Y + offsetY);
                offsetY += 18;
            }
        }
        private void lvwCelulares_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwCelulares.Invalidate();
        }

        #endregion

        private void btnListar_Click(object sender, EventArgs e)
        {
            lvwCelulares.Items.Clear();
            try
            {
                foreach (CelularBaseDTO dto in this.service.ObtenerTodos())
                {
                    ListViewItem item = new ListViewItem(dto.ToString());
                    item.Tag = dto;
                    lvwCelulares.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
        }

        private void btnAgregarS_Click(object sender, EventArgs e)
        {
            try
            {
                SamsungDTO dto = new SamsungDTO();
                dto.model = tbModeloS.Text;
                dto.precio = Convert.ToDouble(tbPrecioS.Text);
                dto.serie = tbSerie.Text;
                dto.stock = Convert.ToInt32(tbStockS.Text);
                MessageBox.Show($"{this.service.AgregarSamsung(dto)}\n¡ Celular agregado con éxito !");

                btnListarS.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            finally
            {
                Limpiar();
            }
        }

        private void btnListarS_Click(object sender, EventArgs e)
        {
            lsbS.Items.Clear();
            try
            {
                foreach (SamsungDTO dto in this.service.ObtenerTodosSamsung())
                {
                    lsbS.Items.Add(dto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
        }

        private void btnListarI_Click(object sender, EventArgs e)
        {
            lsbI.Items.Clear();
            try
            {
                foreach (IphoneDTO dto in this.service.ObtenerTodosIphone())
                {
                    lsbI.Items.Add(dto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
        }

        private void btnAgregarI_Click(object sender, EventArgs e)
        {
            try
            {
                IphoneDTO dto = new IphoneDTO();
                dto.model = tbModeloI.Text;
                dto.precio = Convert.ToDouble(tbPrecioI.Text);
                dto.cond_bateria = tbBateria.Text;
                dto.stock = Convert.ToInt32(tbStockI.Text);
                MessageBox.Show($"{this.service.AgregarIphone(dto)}\n¡ Celular agregado con éxito !");

                ActualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            finally
            {
                Limpiar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lvwCelulares.Items.Clear();

            try
            {
                ListViewItem item = new ListViewItem();
                int id = Convert.ToInt32(tbId.Text);
                if (rdbtnIphone.Checked)
                {
                    item.Tag = this.service.ObtenerIphonePorId(id);
                    lvwCelulares.Items.Add(item.Tag.ToString());
                }
                else if (rdbtnSamsung.Checked)
                {
                    item.Tag = this.service.ObtenerSamsungPorId(id);
                    lvwCelulares.Items.Add(item.Tag.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            finally
            {
                rdbtnIphone.Checked = false;
                rdbtnSamsung.Checked = false;
                tbId.Text = string.Empty;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsbI.SelectedItem != null)
                {
                    IphoneDTO dto = lsbI.SelectedItem as IphoneDTO;
                    if (dto != null)
                    {
                        dto = AsignarDatosDTOIphone(dto);
                        this.service.ActualizarIphone(dto);
                        MessageBox.Show("¡ IPhone actualizado con éxito !");
                    }
                }
                else if (lsbS.SelectedItem != null)
                {
                    SamsungDTO dto = lsbS.SelectedItem as SamsungDTO;
                    if (dto != null)
                    {
                        dto = AsignarDatosDTOSamsung(dto);
                        this.service.ActualizarSamsung(dto);
                        MessageBox.Show("¡ Samsung actualizado con éxito !");
                    }
                }
                else
                {
                    CelularBaseDTO dto = lvwCelulares.SelectedItems[0].Tag as CelularBaseDTO;
                    if (dto != null)
                    {
                        if (dto is IphoneDTO)
                        {
                            IphoneDTO i = AsignarDatosDTOIphone(dto as IphoneDTO);
                            this.service.ActualizarIphone(i);
                            MessageBox.Show("¡ IPhone actualizado con éxito !");
                        }
                        else
                        {
                            SamsungDTO s = AsignarDatosDTOSamsung(dto as SamsungDTO);
                            this.service.ActualizarSamsung(s);
                            MessageBox.Show("¡ Samsung actualizado con éxito !");
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            finally
            {
                Limpiar();

                ActualizarLista();
            }
        }

        private void lsbS_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpiamos
            Limpiar();
            lsbI.ClearSelected();
            btnListar.PerformClick();


            SamsungDTO dto = lsbS.SelectedItem as SamsungDTO;
            if (dto != null)
            {
                tbModeloS.Text = dto.model;
                tbPrecioS.Text = dto.precio.ToString();
                tbSerie.Text = dto.serie;
                tbStockS.Text = dto.stock.ToString();
            }
        }

        private void lsbI_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpiamos
            Limpiar();
            lsbS.ClearSelected();
            btnListar.PerformClick();


            IphoneDTO dto = lsbI.SelectedItem as IphoneDTO;
            if (dto != null)
            {
                tbModeloI.Text = dto.model;
                tbPrecioI.Text = dto.precio.ToString();
                tbBateria.Text = dto.cond_bateria;
                tbStockI.Text = dto.stock.ToString();
            }
        }

        private void lvwCelulares_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Limpiamos
            Limpiar();
            lsbI.ClearSelected();
            lsbS.ClearSelected();

            try
            {
                ListViewItem item = lvwCelulares.SelectedItems[0];
                CelularBaseDTO dto = item.Tag as CelularBaseDTO;
                if (dto != null)
                {
                    if (dto is IphoneDTO)
                    {
                        IphoneDTO i = dto as IphoneDTO;
                        tbModeloI.Text = i.model;
                        tbPrecioI.Text = i.precio.ToString();
                        tbBateria.Text = i.cond_bateria;
                        tbStockI.Text = i.stock.ToString();
                    }
                    else
                    {
                        SamsungDTO s = dto as SamsungDTO;
                        tbModeloS.Text = s.model;
                        tbPrecioS.Text = s.precio.ToString();
                        tbSerie.Text = s.serie;
                        tbStockS.Text = s.stock.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            finally
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tbId.Text);
                this.service.EliminarCelular(id);
                MessageBox.Show("¡ Celular eliminado con éxito !");

                ActualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
        }

        private void ActualizarLista()
        {
            btnListar.PerformClick();
            btnListarI.PerformClick();
            btnListarS.PerformClick();
        }

        private void Limpiar()
        {
            tbModeloS.Text = string.Empty;
            tbPrecioS.Text = string.Empty;
            tbSerie.Text = string.Empty;
            tbStockS.Text = string.Empty;

            tbModeloI.Text = string.Empty;
            tbPrecioI.Text = string.Empty;
            tbBateria.Text = string.Empty;
            tbStockI.Text = string.Empty;

            rdbtnIphone.Checked = false;
            rdbtnSamsung.Checked = false;
        }

        private IphoneDTO AsignarDatosDTOIphone(IphoneDTO iphone)
        {
                iphone.model = tbModeloI.Text;
                iphone.precio = Convert.ToDouble(tbPrecioI.Text);
                iphone.cond_bateria = tbBateria.Text;
                iphone.stock = Convert.ToInt32(tbStockI.Text);
                return iphone;
        }
        private SamsungDTO AsignarDatosDTOSamsung(SamsungDTO samsung)
        {
            samsung.model = tbModeloS.Text;
            samsung.precio = Convert.ToDouble(tbPrecioS.Text);
            samsung.serie = tbSerie.Text;
            samsung.stock = Convert.ToInt32(tbStockS.Text);
            return samsung;
        }
    }
}
