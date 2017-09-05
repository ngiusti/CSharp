using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PapaBobs.DTO.Enums;

namespace PapaBobs.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please Enter Name";
                validationLabel.Visible = true;
                return;
            }
            if (addressTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please Enter An Address.";
                validationLabel.Visible = true;
                return;
            }
            if (zipTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please Enter A Zip.";
                validationLabel.Visible = true;
                return;
            }
            if (phoneTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please Enter A Phone Number";
                validationLabel.Visible = true;
                return;
            }

            try
            {
                var order = buildOrder();
                Domain2.OrderManager.CreateOrder(order);
                Response.Redirect("success.aspx");
            }
            catch (Exception ex)
            {

                validationLabel.Text = ex.Message;
                validationLabel.Visible = true;
                return;
            }
            
        }

        private DTO.Enums.PaymentType determinePaymentType()
        {
            DTO.Enums.PaymentType paymentType;
            if (cashRadioButton.Checked)
            {   
                paymentType = DTO.Enums.PaymentType.Cash;
            }
            else
            {
                paymentType = DTO.Enums.PaymentType.Credit;
            }
            
            return paymentType;
        }

        private CrustType determineCrust()
        {
            DTO.Enums.CrustType crust;
            if (!Enum.TryParse(crustDropDownList.SelectedValue, out crust))
            {
                throw new Exception("Could not Determine Pizza Crust.");
            }
            return crust;
        }

        private DTO.Enums.SizeType determineSize()
        {
            DTO.Enums.SizeType size;
            if (!Enum.TryParse(sizeDropDownList.SelectedValue, out size))
            {
                throw new Exception("Could not Determine Pizza Size.");
            }
            return size;
        }

        protected void recalculateTotalCost(object sender, EventArgs e)
        {
            if (sizeDropDownList.SelectedValue == String.Empty) return;
            if (crustDropDownList.SelectedValue == String.Empty) return;

            var order = buildOrder();
            try
            {
                totalLabel.Text = Domain2.PizzPriceManager.CalculatePizzaPirce(order).ToString("C");

            }
            catch 
            {

                // Swallow the error
            }
            
        }

        private DTO.OrderDTO buildOrder()
        {
            var order = new DTO.OrderDTO();
            order.Size = determineSize();
            order.Crust = determineCrust();
            order.Sausage_ = sausageCheckBox.Checked;
            order.Pepperoni = pepperoniCheckBox.Checked;
            order.Onions = onionsCheckBox.Checked;
            order.GreenPeppers = greenPeppersCheckBox.Checked;
            order.Name = nameTextBox.Text;
            order.Address = addressTextBox.Text;
            order.Zip = zipTextBox.Text;
            order.Phone = phoneTextBox.Text;
            order.PaymentType = determinePaymentType();
            return order;
        }
    }
}