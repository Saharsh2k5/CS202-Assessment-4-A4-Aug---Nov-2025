using System.Collections.Generic;

namespace OrderPipeline
{
   public class OrderEventArgs : EventArgs
    {
        public string CustomerName { get; }
        public string Product { get; }
        public int Quantity { get; }

        public OrderEventArgs(string customerName, string product, int quantity)
        {
            CustomerName = customerName;
            Product = product;
            Quantity = quantity;
        }
    }

    public class ShipEventArgs : EventArgs
    {
        public string Product { get; }
        public bool Express { get; }

        public ShipEventArgs(string p, bool ex)
            => (Product, Express) = (p, ex);
    }
    public partial class Form1 : Form
    {
        public event EventHandler<OrderEventArgs>? OrderCreated;
        public event EventHandler<OrderEventArgs>? OrderRejected;
        public event EventHandler<OrderEventArgs>? OrderConfirmed;

        //Task 2 event - OrderShipped with ShipEventArgs
        public event EventHandler<ShipEventArgs>? OrderShipped;
        private bool isOrderConfirmed = false;
        private string currentProduct = string.Empty;
        public Form1()
        {
            InitializeComponent();
            OrderCreated += ValidateOrder;
            OrderCreated += DisplayOrderInfo;
            OrderRejected += ShowRejection;
            OrderConfirmed += ShowConfirmation;

            OrderShipped += ShowDispatch;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize ComboBox with product options
            cmbProduct.Items.AddRange(new object[] { "Laptop", "Mouse", "Keyboard" });
            cmbProduct.SelectedIndex = 0;

            // Set default quantity
            numQuantity.Minimum = 0;
            numQuantity.Maximum = 100;
            numQuantity.Value = 1;

            // Initialize status label
            lblStatus.Text = "Ready";

            //Task 2 - Disable ship button initially
            btnShipOrder.Enabled = false;
        }
        private void btnProcessOrder_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Please enter a customer name.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProduct.SelectedItem == null)
            {
                MessageBox.Show("Please select a product.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isOrderConfirmed = false;
            btnShipOrder.Enabled = false;

            // Create order and raise OrderCreated event
            var orderArgs = new OrderEventArgs(
                txtCustomerName.Text,
                cmbProduct.SelectedItem.ToString()!,
                (int)numQuantity.Value
            );

            OrderCreated?.Invoke(this, orderArgs);
        }

        //Task 2 - Ship Order button click handler
        private void btnShipOrder_Click(object sender, EventArgs e)
        {
            // Event Filtering: Check if order was confirmed using boolean flag
            if (!isOrderConfirmed)
            {
                MessageBox.Show("Please process and confirm an order first.",
                    "Order Not Confirmed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dynamic Subscriber Management: Add/Remove NotifyCourier based on checkbox
            if (chkExpress.Checked)
            {
                // Add NotifyCourier subscriber for express delivery
                OrderShipped -= NotifyCourier; // Remove first to avoid duplicate subscription
                OrderShipped += NotifyCourier; // Add the subscriber
            }
            else
            {
                // Remove NotifyCourier subscriber for regular delivery
                OrderShipped -= NotifyCourier;
            }

            // Create shipping event args and raise OrderShipped event
            var shipArgs = new ShipEventArgs(currentProduct, chkExpress.Checked);
            OrderShipped?.Invoke(this, shipArgs);

            // Reset after shipping
            isOrderConfirmed = false;
            btnShipOrder.Enabled = false;
        }

        //Task 2 - Express checkbox changed event handler
        private void chkExpress_CheckedChanged(object sender, EventArgs e)
        {
            // Visual feedback for express option
            if (chkExpress.Checked)
            {
                chkExpress.ForeColor = Color.DarkOrange;
                chkExpress.Font = new Font(chkExpress.Font, FontStyle.Bold);
            }
            else
            {
                chkExpress.ForeColor = SystemColors.ControlText;
                chkExpress.Font = new Font(chkExpress.Font, FontStyle.Regular);
            }
        }

        // Event Subscriber: Validates the order
        private void ValidateOrder(object? sender, OrderEventArgs e)
        {
            if (e.Quantity > 0)
            {
                lblStatus.Text = "Validated";

                //Task 2 - Store current product for shipping
                currentProduct = e.Product;

                // Chain to OrderConfirmed event
                OrderConfirmed?.Invoke(this, e);
            }
            else
            {
                // Chain to OrderRejected event
                OrderRejected?.Invoke(this, e);
            }
        }

        // Event Subscriber: Displays order information
        private void DisplayOrderInfo(object? sender, OrderEventArgs e)
        {
            string orderSummary = $"Order Summary:\n\n" +
                                 $"Customer: {e.CustomerName}\n" +
                                 $"Product: {e.Product}\n" +
                                 $"Quantity: {e.Quantity}";

            MessageBox.Show(orderSummary, "Order Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Event Subscriber: Handles order rejection
        private void ShowRejection(object? sender, OrderEventArgs e)
        {
            lblStatus.Text = "Order Invalid – Please retry";
            lblStatus.ForeColor = Color.Red;

            //Task 2 - Ensure flags are reset on rejection
            isOrderConfirmed = false;
            btnShipOrder.Enabled = false;
        }

        // Event Subscriber: Handles order confirmation
        private void ShowConfirmation(object? sender, OrderEventArgs e)
        {
            lblStatus.Text = $"Order Processed Successfully for {e.CustomerName}";
            lblStatus.ForeColor = Color.Green;

            //Task 2 - Set flag to true and enable ship button
            isOrderConfirmed = true;
            btnShipOrder.Enabled = true;
        }

        // Event Subscriber: Shows dispatch information (ALWAYS SUBSCRIBED)
        private void ShowDispatch(object? sender, ShipEventArgs e)
        {
            string shippingType = e.Express ? "Express" : "Standard";
            lblStatus.Text = $"Product dispatched: {e.Product} ({shippingType})";
            lblStatus.ForeColor = Color.Blue;
        }

        // Event Subscriber: Notifies courier for express delivery (DYNAMICALLY SUBSCRIBED)
        private void NotifyCourier(object? sender, ShipEventArgs e)
        {
            if (e.Express)
            {
                MessageBox.Show($"Express delivery initiated!\n\n" +
                              $"Product: {e.Product}\n" +
                              $"Priority: HIGH\n" +
                              $"Courier has been notified.",
                              "Express Shipping",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
        }

    }

}
