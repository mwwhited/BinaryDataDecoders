using System.ComponentModel;
using System.Text.RegularExpressions;

namespace BinaryDataDecoders.Windows.Forms
{
    public partial class ValidTextBox : TextBox
    {
        private string? _filter;

        [Category("Validation Rules")]
        [Description("Regular Expression (Regex) for validation patterns")]
        public string? Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                OnFilterChanged(new EventArgs());
            }
        }

        [Category("Validation Rules")]
        [Description("Background Color if input is Valid")]
        public Color ValidColor { get; set; }

        [Category("Validation Rules")]
        [Description("Background Color if input is Invalid")]
        public Color InvalidColor { get; set; }

        public ValidTextBox()
        {
            ValidColor = Color.LightGreen;
            InvalidColor = Color.LightPink;

            InitLayout();
            //InitializeComponent();
            Validate();
        }

        public event EventHandler<ValidationEventArgs>? ValidateChanged;

        public bool IsValid =>
            string.IsNullOrWhiteSpace(Filter) ||
            Regex.IsMatch(Text, Filter);

        private bool _lastValidate;
        public void Validate()
        {
            var validated = IsValid;
            BackColor = validated ? ValidColor : InvalidColor;
            if (_lastValidate != validated)
            {
                ValidateChanged?.Invoke(this, new ValidationEventArgs { IsValid = validated, Value = Text });
                _lastValidate = validated;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Validate();
        }

        protected virtual void OnFilterChanged(EventArgs e)
        {
            Validate();
        }

        ///// <summary> 
        ///// Required method for Designer support - do not modify 
        ///// the contents of this method with the code editor.
        ///// </summary>
        //private void InitializeComponent()
        //{
        //    //components = new System.ComponentModel.Container();
        //    //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //}

        //protected override void OnValidating(CancelEventArgs e)
        //{
        //    base.OnValidating(e);
        //}

        //protected override void OnValidated(EventArgs e)
        //{
        //    base.OnValidated(e);
        //}

        //protected override void OnInvalidated(InvalidateEventArgs e)
        //{
        //    base.OnInvalidated(e);
        //}
    }
}