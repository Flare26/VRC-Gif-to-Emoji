namespace VRC_GIF_to_Emoji
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.TableLayoutPanel rootLayout;

        // Top bar
        private System.Windows.Forms.TableLayoutPanel topBar;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnLoadUrl;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblDropHint;

        // Center
        private System.Windows.Forms.SplitContainer centerSplit;
        private PreviewControl preview;
        private System.Windows.Forms.TabControl toolsTabs;

        // Frames tab
        private System.Windows.Forms.TabPage tabFrames;
        private System.Windows.Forms.ListBox lstFrames;
        private System.Windows.Forms.Button btnFrameDelete;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Label lblKeepEvery;
        private System.Windows.Forms.NumericUpDown numKeepEvery;
        private System.Windows.Forms.Button btnKeepEvery;
        private System.Windows.Forms.Label lblTrim;
        private System.Windows.Forms.NumericUpDown numTrimStart;
        private System.Windows.Forms.Label lblTrimDash;
        private System.Windows.Forms.NumericUpDown numTrimEnd;
        private System.Windows.Forms.Button btnTrim;

        // Effects tab
        private System.Windows.Forms.TabPage tabEffects;
        private System.Windows.Forms.Button btnRotateLeft;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.Button btnFlipH;
        private System.Windows.Forms.Button btnFlipV;
        private System.Windows.Forms.Button btnResetCrop;
        private System.Windows.Forms.Label lblEffectsHint;

        // Speed tab
        private System.Windows.Forms.TabPage tabSpeed;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.NumericUpDown numFps;
        private System.Windows.Forms.TrackBar trkFps;

        // Output tab
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkAutoGrid;
        private System.Windows.Forms.Label lblCols;
        private System.Windows.Forms.NumericUpDown numCols;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.CheckBox chkShowGrid;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSave;

        // Status
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;

        // Layout panels (tab internals)
        private System.Windows.Forms.TableLayoutPanel framesRoot;
        private System.Windows.Forms.FlowLayoutPanel framesRowButtons;
        private System.Windows.Forms.FlowLayoutPanel framesRowKeep;
        private System.Windows.Forms.FlowLayoutPanel framesRowTrim;
        private System.Windows.Forms.TableLayoutPanel effectsRoot;
        private System.Windows.Forms.FlowLayoutPanel effectsRowRotate;
        private System.Windows.Forms.FlowLayoutPanel effectsRowFlip;
        private System.Windows.Forms.TableLayoutPanel speedRoot;
        private System.Windows.Forms.FlowLayoutPanel speedRowFps;
        private System.Windows.Forms.TableLayoutPanel outputRoot;
        private System.Windows.Forms.FlowLayoutPanel outputRowName;
        private System.Windows.Forms.FlowLayoutPanel outputRowGrid;

        private void InitializeComponent()
        {
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.topBar = new System.Windows.Forms.TableLayoutPanel();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnLoadUrl = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblDropHint = new System.Windows.Forms.Label();
            this.centerSplit = new System.Windows.Forms.SplitContainer();
            this.preview = new VRC_GIF_to_Emoji.PreviewControl();
            this.toolsTabs = new System.Windows.Forms.TabControl();
            this.tabFrames = new System.Windows.Forms.TabPage();
            this.framesRoot = new System.Windows.Forms.TableLayoutPanel();
            this.lstFrames = new System.Windows.Forms.ListBox();
            this.framesRowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFrameDelete = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.framesRowKeep = new System.Windows.Forms.FlowLayoutPanel();
            this.lblKeepEvery = new System.Windows.Forms.Label();
            this.numKeepEvery = new System.Windows.Forms.NumericUpDown();
            this.btnKeepEvery = new System.Windows.Forms.Button();
            this.lblTrim = new System.Windows.Forms.Label();
            this.framesRowTrim = new System.Windows.Forms.FlowLayoutPanel();
            this.numTrimStart = new System.Windows.Forms.NumericUpDown();
            this.lblTrimDash = new System.Windows.Forms.Label();
            this.numTrimEnd = new System.Windows.Forms.NumericUpDown();
            this.btnTrim = new System.Windows.Forms.Button();
            this.tabEffects = new System.Windows.Forms.TabPage();
            this.effectsRoot = new System.Windows.Forms.TableLayoutPanel();
            this.effectsRowRotate = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.effectsRowFlip = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFlipH = new System.Windows.Forms.Button();
            this.btnFlipV = new System.Windows.Forms.Button();
            this.btnResetCrop = new System.Windows.Forms.Button();
            this.lblEffectsHint = new System.Windows.Forms.Label();
            this.tabSpeed = new System.Windows.Forms.TabPage();
            this.speedRoot = new System.Windows.Forms.TableLayoutPanel();
            this.speedRowFps = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFps = new System.Windows.Forms.Label();
            this.numFps = new System.Windows.Forms.NumericUpDown();
            this.trkFps = new System.Windows.Forms.TrackBar();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.outputRoot = new System.Windows.Forms.TableLayoutPanel();
            this.outputRowName = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkAutoGrid = new System.Windows.Forms.CheckBox();
            this.outputRowGrid = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCols = new System.Windows.Forms.Label();
            this.numCols = new System.Windows.Forms.NumericUpDown();
            this.lblRows = new System.Windows.Forms.Label();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.chkShowGrid = new System.Windows.Forms.CheckBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.rootLayout.SuspendLayout();
            this.topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.centerSplit)).BeginInit();
            this.centerSplit.Panel1.SuspendLayout();
            this.centerSplit.Panel2.SuspendLayout();
            this.centerSplit.SuspendLayout();
            this.toolsTabs.SuspendLayout();
            this.tabFrames.SuspendLayout();
            this.framesRoot.SuspendLayout();
            this.framesRowButtons.SuspendLayout();
            this.framesRowKeep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKeepEvery)).BeginInit();
            this.framesRowTrim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTrimStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrimEnd)).BeginInit();
            this.tabEffects.SuspendLayout();
            this.effectsRoot.SuspendLayout();
            this.effectsRowRotate.SuspendLayout();
            this.effectsRowFlip.SuspendLayout();
            this.tabSpeed.SuspendLayout();
            this.speedRoot.SuspendLayout();
            this.speedRowFps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkFps)).BeginInit();
            this.tabOutput.SuspendLayout();
            this.outputRoot.SuspendLayout();
            this.outputRowName.SuspendLayout();
            this.outputRowGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rootLayout
            // 
            this.rootLayout.ColumnCount = 1;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Controls.Add(this.topBar, 0, 0);
            this.rootLayout.Controls.Add(this.centerSplit, 0, 1);
            this.rootLayout.Controls.Add(this.statusStrip, 0, 2);
            this.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootLayout.Location = new System.Drawing.Point(0, 0);
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.RowCount = 3;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rootLayout.Size = new System.Drawing.Size(1280, 760);
            this.rootLayout.TabIndex = 0;
            // 
            // topBar
            // 
            this.topBar.AutoSize = true;
            this.topBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topBar.ColumnCount = 3;
            this.topBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topBar.Controls.Add(this.txtUrl, 0, 0);
            this.topBar.Controls.Add(this.btnLoadUrl, 1, 0);
            this.topBar.Controls.Add(this.btnBrowse, 2, 0);
            this.topBar.Controls.Add(this.lblDropHint, 0, 1);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBar.Location = new System.Drawing.Point(3, 3);
            this.topBar.Name = "topBar";
            this.topBar.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.topBar.RowCount = 2;
            this.topBar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topBar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topBar.Size = new System.Drawing.Size(1274, 54);
            this.topBar.TabIndex = 0;
            // 
            // txtUrl
            // 
            this.txtUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUrl.Location = new System.Drawing.Point(8, 12);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(0, 4, 6, 0);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(1056, 20);
            this.txtUrl.TabIndex = 0;
            // 
            // btnLoadUrl
            // 
            this.btnLoadUrl.Location = new System.Drawing.Point(1070, 10);
            this.btnLoadUrl.Margin = new System.Windows.Forms.Padding(0, 2, 4, 0);
            this.btnLoadUrl.Name = "btnLoadUrl";
            this.btnLoadUrl.Size = new System.Drawing.Size(96, 23);
            this.btnLoadUrl.TabIndex = 1;
            this.btnLoadUrl.Text = "Load URL";
            this.btnLoadUrl.Click += new System.EventHandler(this.OnLoadUrlClick);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(1170, 10);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(96, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse…";
            this.btnBrowse.Click += new System.EventHandler(this.OnBrowseClick);
            // 
            // lblDropHint
            // 
            this.lblDropHint.AutoSize = true;
            this.topBar.SetColumnSpan(this.lblDropHint, 3);
            this.lblDropHint.ForeColor = System.Drawing.Color.Gray;
            this.lblDropHint.Location = new System.Drawing.Point(8, 37);
            this.lblDropHint.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblDropHint.Name = "lblDropHint";
            this.lblDropHint.Size = new System.Drawing.Size(192, 13);
            this.lblDropHint.TabIndex = 3;
            this.lblDropHint.Text = "…or drop a file anywhere on the window";
            // 
            // centerSplit
            // 
            this.centerSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.centerSplit.Location = new System.Drawing.Point(3, 63);
            this.centerSplit.Name = "centerSplit";
            // 
            // centerSplit.Panel1
            // 
            this.centerSplit.Panel1.Controls.Add(this.preview);
            this.centerSplit.Panel1MinSize = 300;
            // 
            // centerSplit.Panel2
            // 
            this.centerSplit.Panel2.Controls.Add(this.toolsTabs);
            this.centerSplit.Panel2MinSize = 320;
            this.centerSplit.Size = new System.Drawing.Size(1274, 672);
            this.centerSplit.SplitterDistance = 850;
            this.centerSplit.TabIndex = 1;
            // 
            // preview
            // 
            this.preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preview.Location = new System.Drawing.Point(0, 0);
            this.preview.MinimumSize = new System.Drawing.Size(200, 200);
            this.preview.Name = "preview";
            this.preview.ShowGrid = false;
            this.preview.Size = new System.Drawing.Size(850, 672);
            this.preview.TabIndex = 0;
            // 
            // toolsTabs
            // 
            this.toolsTabs.Controls.Add(this.tabFrames);
            this.toolsTabs.Controls.Add(this.tabEffects);
            this.toolsTabs.Controls.Add(this.tabSpeed);
            this.toolsTabs.Controls.Add(this.tabOutput);
            this.toolsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsTabs.Location = new System.Drawing.Point(0, 0);
            this.toolsTabs.Name = "toolsTabs";
            this.toolsTabs.SelectedIndex = 0;
            this.toolsTabs.Size = new System.Drawing.Size(420, 672);
            this.toolsTabs.TabIndex = 0;
            // 
            // tabFrames
            // 
            this.tabFrames.Controls.Add(this.framesRoot);
            this.tabFrames.Location = new System.Drawing.Point(4, 22);
            this.tabFrames.Name = "tabFrames";
            this.tabFrames.Padding = new System.Windows.Forms.Padding(8);
            this.tabFrames.Size = new System.Drawing.Size(412, 646);
            this.tabFrames.TabIndex = 0;
            this.tabFrames.Text = "Frames";
            this.tabFrames.UseVisualStyleBackColor = true;
            // 
            // framesRoot
            // 
            this.framesRoot.ColumnCount = 1;
            this.framesRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.framesRoot.Controls.Add(this.lstFrames, 0, 0);
            this.framesRoot.Controls.Add(this.framesRowButtons, 0, 1);
            this.framesRoot.Controls.Add(this.framesRowKeep, 0, 2);
            this.framesRoot.Controls.Add(this.lblTrim, 0, 3);
            this.framesRoot.Controls.Add(this.framesRowTrim, 0, 4);
            this.framesRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.framesRoot.Location = new System.Drawing.Point(8, 8);
            this.framesRoot.Name = "framesRoot";
            this.framesRoot.RowCount = 5;
            this.framesRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.framesRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.framesRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.framesRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.framesRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.framesRoot.Size = new System.Drawing.Size(396, 630);
            this.framesRoot.TabIndex = 0;
            // 
            // lstFrames
            // 
            this.lstFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFrames.IntegralHeight = false;
            this.lstFrames.Location = new System.Drawing.Point(3, 3);
            this.lstFrames.Name = "lstFrames";
            this.lstFrames.Size = new System.Drawing.Size(390, 516);
            this.lstFrames.TabIndex = 0;
            this.lstFrames.SelectedIndexChanged += new System.EventHandler(this.OnFrameListSelected);
            // 
            // framesRowButtons
            // 
            this.framesRowButtons.AutoSize = true;
            this.framesRowButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.framesRowButtons.Controls.Add(this.btnFrameDelete);
            this.framesRowButtons.Controls.Add(this.btnReverse);
            this.framesRowButtons.Location = new System.Drawing.Point(0, 528);
            this.framesRowButtons.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.framesRowButtons.Name = "framesRowButtons";
            this.framesRowButtons.Size = new System.Drawing.Size(172, 23);
            this.framesRowButtons.TabIndex = 1;
            this.framesRowButtons.WrapContents = false;
            // 
            // btnFrameDelete
            // 
            this.btnFrameDelete.AutoSize = true;
            this.btnFrameDelete.Location = new System.Drawing.Point(0, 0);
            this.btnFrameDelete.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnFrameDelete.Name = "btnFrameDelete";
            this.btnFrameDelete.Size = new System.Drawing.Size(91, 23);
            this.btnFrameDelete.TabIndex = 0;
            this.btnFrameDelete.Text = "Delete selected";
            this.btnFrameDelete.Click += new System.EventHandler(this.OnDeleteFrameClick);
            // 
            // btnReverse
            // 
            this.btnReverse.AutoSize = true;
            this.btnReverse.Location = new System.Drawing.Point(97, 0);
            this.btnReverse.Margin = new System.Windows.Forms.Padding(0);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(75, 23);
            this.btnReverse.TabIndex = 1;
            this.btnReverse.Text = "Reverse all";
            this.btnReverse.Click += new System.EventHandler(this.OnReverseClick);
            // 
            // framesRowKeep
            // 
            this.framesRowKeep.AutoSize = true;
            this.framesRowKeep.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.framesRowKeep.Controls.Add(this.lblKeepEvery);
            this.framesRowKeep.Controls.Add(this.numKeepEvery);
            this.framesRowKeep.Controls.Add(this.btnKeepEvery);
            this.framesRowKeep.Location = new System.Drawing.Point(0, 557);
            this.framesRowKeep.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.framesRowKeep.Name = "framesRowKeep";
            this.framesRowKeep.Size = new System.Drawing.Size(260, 23);
            this.framesRowKeep.TabIndex = 2;
            this.framesRowKeep.WrapContents = false;
            // 
            // lblKeepEvery
            // 
            this.lblKeepEvery.AutoSize = true;
            this.lblKeepEvery.Location = new System.Drawing.Point(0, 6);
            this.lblKeepEvery.Margin = new System.Windows.Forms.Padding(0, 6, 6, 0);
            this.lblKeepEvery.Name = "lblKeepEvery";
            this.lblKeepEvery.Size = new System.Drawing.Size(113, 13);
            this.lblKeepEvery.TabIndex = 0;
            this.lblKeepEvery.Text = "Keep every Nth frame:";
            // 
            // numKeepEvery
            // 
            this.numKeepEvery.Location = new System.Drawing.Point(119, 3);
            this.numKeepEvery.Margin = new System.Windows.Forms.Padding(0, 3, 6, 0);
            this.numKeepEvery.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numKeepEvery.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numKeepEvery.Name = "numKeepEvery";
            this.numKeepEvery.Size = new System.Drawing.Size(60, 20);
            this.numKeepEvery.TabIndex = 1;
            this.numKeepEvery.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnKeepEvery
            // 
            this.btnKeepEvery.AutoSize = true;
            this.btnKeepEvery.Location = new System.Drawing.Point(185, 0);
            this.btnKeepEvery.Margin = new System.Windows.Forms.Padding(0);
            this.btnKeepEvery.Name = "btnKeepEvery";
            this.btnKeepEvery.Size = new System.Drawing.Size(75, 23);
            this.btnKeepEvery.TabIndex = 2;
            this.btnKeepEvery.Text = "Apply";
            this.btnKeepEvery.Click += new System.EventHandler(this.OnKeepEveryClick);
            // 
            // lblTrim
            // 
            this.lblTrim.AutoSize = true;
            this.lblTrim.Location = new System.Drawing.Point(0, 590);
            this.lblTrim.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblTrim.Name = "lblTrim";
            this.lblTrim.Size = new System.Drawing.Size(154, 13);
            this.lblTrim.TabIndex = 3;
            this.lblTrim.Text = "Trim (start..end, end exclusive):";
            // 
            // framesRowTrim
            // 
            this.framesRowTrim.AutoSize = true;
            this.framesRowTrim.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.framesRowTrim.Controls.Add(this.numTrimStart);
            this.framesRowTrim.Controls.Add(this.lblTrimDash);
            this.framesRowTrim.Controls.Add(this.numTrimEnd);
            this.framesRowTrim.Controls.Add(this.btnTrim);
            this.framesRowTrim.Location = new System.Drawing.Point(0, 607);
            this.framesRowTrim.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.framesRowTrim.Name = "framesRowTrim";
            this.framesRowTrim.Size = new System.Drawing.Size(242, 23);
            this.framesRowTrim.TabIndex = 4;
            this.framesRowTrim.WrapContents = false;
            // 
            // numTrimStart
            // 
            this.numTrimStart.Location = new System.Drawing.Point(0, 3);
            this.numTrimStart.Margin = new System.Windows.Forms.Padding(0, 3, 4, 0);
            this.numTrimStart.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numTrimStart.Name = "numTrimStart";
            this.numTrimStart.Size = new System.Drawing.Size(70, 20);
            this.numTrimStart.TabIndex = 0;
            // 
            // lblTrimDash
            // 
            this.lblTrimDash.AutoSize = true;
            this.lblTrimDash.Location = new System.Drawing.Point(74, 6);
            this.lblTrimDash.Margin = new System.Windows.Forms.Padding(0, 6, 4, 0);
            this.lblTrimDash.Name = "lblTrimDash";
            this.lblTrimDash.Size = new System.Drawing.Size(13, 13);
            this.lblTrimDash.TabIndex = 1;
            this.lblTrimDash.Text = "—";
            // 
            // numTrimEnd
            // 
            this.numTrimEnd.Location = new System.Drawing.Point(91, 3);
            this.numTrimEnd.Margin = new System.Windows.Forms.Padding(0, 3, 6, 0);
            this.numTrimEnd.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numTrimEnd.Name = "numTrimEnd";
            this.numTrimEnd.Size = new System.Drawing.Size(70, 20);
            this.numTrimEnd.TabIndex = 2;
            // 
            // btnTrim
            // 
            this.btnTrim.AutoSize = true;
            this.btnTrim.Location = new System.Drawing.Point(167, 0);
            this.btnTrim.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrim.Name = "btnTrim";
            this.btnTrim.Size = new System.Drawing.Size(75, 23);
            this.btnTrim.TabIndex = 3;
            this.btnTrim.Text = "Trim";
            this.btnTrim.Click += new System.EventHandler(this.OnTrimClick);
            // 
            // tabEffects
            // 
            this.tabEffects.Controls.Add(this.effectsRoot);
            this.tabEffects.Location = new System.Drawing.Point(4, 22);
            this.tabEffects.Name = "tabEffects";
            this.tabEffects.Padding = new System.Windows.Forms.Padding(8);
            this.tabEffects.Size = new System.Drawing.Size(412, 646);
            this.tabEffects.TabIndex = 1;
            this.tabEffects.Text = "Effects";
            this.tabEffects.UseVisualStyleBackColor = true;
            // 
            // effectsRoot
            // 
            this.effectsRoot.ColumnCount = 1;
            this.effectsRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.effectsRoot.Controls.Add(this.effectsRowRotate, 0, 0);
            this.effectsRoot.Controls.Add(this.effectsRowFlip, 0, 1);
            this.effectsRoot.Controls.Add(this.btnResetCrop, 0, 2);
            this.effectsRoot.Controls.Add(this.lblEffectsHint, 0, 3);
            this.effectsRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.effectsRoot.Location = new System.Drawing.Point(8, 8);
            this.effectsRoot.Name = "effectsRoot";
            this.effectsRoot.RowCount = 4;
            this.effectsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.effectsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.effectsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.effectsRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.effectsRoot.Size = new System.Drawing.Size(396, 630);
            this.effectsRoot.TabIndex = 0;
            // 
            // effectsRowRotate
            // 
            this.effectsRowRotate.AutoSize = true;
            this.effectsRowRotate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.effectsRowRotate.Controls.Add(this.btnRotateLeft);
            this.effectsRowRotate.Controls.Add(this.btnRotateRight);
            this.effectsRowRotate.Location = new System.Drawing.Point(0, 0);
            this.effectsRowRotate.Margin = new System.Windows.Forms.Padding(0);
            this.effectsRowRotate.Name = "effectsRowRotate";
            this.effectsRowRotate.Size = new System.Drawing.Size(191, 23);
            this.effectsRowRotate.TabIndex = 0;
            this.effectsRowRotate.WrapContents = false;
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.AutoSize = true;
            this.btnRotateLeft.Location = new System.Drawing.Point(0, 0);
            this.btnRotateLeft.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(89, 23);
            this.btnRotateLeft.TabIndex = 0;
            this.btnRotateLeft.Text = "Rotate Left 90°";
            this.btnRotateLeft.Click += new System.EventHandler(this.OnRotateLeftClick);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.AutoSize = true;
            this.btnRotateRight.Location = new System.Drawing.Point(95, 0);
            this.btnRotateRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(96, 23);
            this.btnRotateRight.TabIndex = 1;
            this.btnRotateRight.Text = "Rotate Right 90°";
            this.btnRotateRight.Click += new System.EventHandler(this.OnRotateRightClick);
            // 
            // effectsRowFlip
            // 
            this.effectsRowFlip.AutoSize = true;
            this.effectsRowFlip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.effectsRowFlip.Controls.Add(this.btnFlipH);
            this.effectsRowFlip.Controls.Add(this.btnFlipV);
            this.effectsRowFlip.Location = new System.Drawing.Point(0, 29);
            this.effectsRowFlip.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.effectsRowFlip.Name = "effectsRowFlip";
            this.effectsRowFlip.Size = new System.Drawing.Size(164, 23);
            this.effectsRowFlip.TabIndex = 1;
            this.effectsRowFlip.WrapContents = false;
            // 
            // btnFlipH
            // 
            this.btnFlipH.AutoSize = true;
            this.btnFlipH.Location = new System.Drawing.Point(0, 0);
            this.btnFlipH.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnFlipH.Name = "btnFlipH";
            this.btnFlipH.Size = new System.Drawing.Size(83, 23);
            this.btnFlipH.TabIndex = 0;
            this.btnFlipH.Text = "Flip Horizontal";
            this.btnFlipH.Click += new System.EventHandler(this.OnFlipHClick);
            // 
            // btnFlipV
            // 
            this.btnFlipV.AutoSize = true;
            this.btnFlipV.Location = new System.Drawing.Point(89, 0);
            this.btnFlipV.Margin = new System.Windows.Forms.Padding(0);
            this.btnFlipV.Name = "btnFlipV";
            this.btnFlipV.Size = new System.Drawing.Size(75, 23);
            this.btnFlipV.TabIndex = 1;
            this.btnFlipV.Text = "Flip Vertical";
            this.btnFlipV.Click += new System.EventHandler(this.OnFlipVClick);
            // 
            // btnResetCrop
            // 
            this.btnResetCrop.AutoSize = true;
            this.btnResetCrop.Location = new System.Drawing.Point(0, 64);
            this.btnResetCrop.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.btnResetCrop.Name = "btnResetCrop";
            this.btnResetCrop.Size = new System.Drawing.Size(130, 23);
            this.btnResetCrop.TabIndex = 3;
            this.btnResetCrop.Text = "Reset Pan / Zoom";
            this.btnResetCrop.UseVisualStyleBackColor = true;
            this.btnResetCrop.Click += new System.EventHandler(this.OnResetCropClick);
            // 
            // lblEffectsHint
            // 
            this.lblEffectsHint.AutoSize = true;
            this.lblEffectsHint.ForeColor = System.Drawing.Color.Gray;
            this.lblEffectsHint.Location = new System.Drawing.Point(0, 103);
            this.lblEffectsHint.Margin = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.lblEffectsHint.Name = "lblEffectsHint";
            this.lblEffectsHint.Size = new System.Drawing.Size(194, 26);
            this.lblEffectsHint.TabIndex = 2;
            this.lblEffectsHint.Text = "Scroll to zoom, drag to pan the preview.\nWhat you see is what gets saved.";
            // 
            // tabSpeed
            // 
            this.tabSpeed.Controls.Add(this.speedRoot);
            this.tabSpeed.Location = new System.Drawing.Point(4, 22);
            this.tabSpeed.Name = "tabSpeed";
            this.tabSpeed.Padding = new System.Windows.Forms.Padding(8);
            this.tabSpeed.Size = new System.Drawing.Size(412, 646);
            this.tabSpeed.TabIndex = 2;
            this.tabSpeed.Text = "Speed";
            this.tabSpeed.UseVisualStyleBackColor = true;
            // 
            // speedRoot
            // 
            this.speedRoot.ColumnCount = 1;
            this.speedRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.speedRoot.Controls.Add(this.speedRowFps, 0, 0);
            this.speedRoot.Controls.Add(this.trkFps, 0, 1);
            this.speedRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedRoot.Location = new System.Drawing.Point(8, 8);
            this.speedRoot.Name = "speedRoot";
            this.speedRoot.RowCount = 3;
            this.speedRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.speedRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.speedRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.speedRoot.Size = new System.Drawing.Size(396, 630);
            this.speedRoot.TabIndex = 0;
            // 
            // speedRowFps
            // 
            this.speedRowFps.AutoSize = true;
            this.speedRowFps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.speedRowFps.Controls.Add(this.lblFps);
            this.speedRowFps.Controls.Add(this.numFps);
            this.speedRowFps.Location = new System.Drawing.Point(0, 0);
            this.speedRowFps.Margin = new System.Windows.Forms.Padding(0);
            this.speedRowFps.Name = "speedRowFps";
            this.speedRowFps.Size = new System.Drawing.Size(145, 23);
            this.speedRowFps.TabIndex = 0;
            this.speedRowFps.WrapContents = false;
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Location = new System.Drawing.Point(0, 6);
            this.lblFps.Margin = new System.Windows.Forms.Padding(0, 6, 8, 0);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(77, 13);
            this.lblFps.TabIndex = 0;
            this.lblFps.Text = "Playback FPS:";
            // 
            // numFps
            // 
            this.numFps.Location = new System.Drawing.Point(85, 3);
            this.numFps.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.numFps.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numFps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFps.Name = "numFps";
            this.numFps.Size = new System.Drawing.Size(60, 20);
            this.numFps.TabIndex = 1;
            this.numFps.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFps.ValueChanged += new System.EventHandler(this.OnFpsChanged);
            // 
            // trkFps
            // 
            this.trkFps.Dock = System.Windows.Forms.DockStyle.Top;
            this.trkFps.Location = new System.Drawing.Point(0, 31);
            this.trkFps.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.trkFps.Maximum = 60;
            this.trkFps.Minimum = 1;
            this.trkFps.Name = "trkFps";
            this.trkFps.Size = new System.Drawing.Size(396, 45);
            this.trkFps.TabIndex = 1;
            this.trkFps.TickFrequency = 5;
            this.trkFps.Value = 10;
            this.trkFps.Scroll += new System.EventHandler(this.OnFpsTrackScroll);
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.outputRoot);
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(8);
            this.tabOutput.Size = new System.Drawing.Size(412, 646);
            this.tabOutput.TabIndex = 3;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // outputRoot
            // 
            this.outputRoot.ColumnCount = 1;
            this.outputRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outputRoot.Controls.Add(this.outputRowName, 0, 0);
            this.outputRoot.Controls.Add(this.chkAutoGrid, 0, 1);
            this.outputRoot.Controls.Add(this.outputRowGrid, 0, 2);
            this.outputRoot.Controls.Add(this.chkShowGrid, 0, 3);
            this.outputRoot.Controls.Add(this.lblFileName, 0, 4);
            this.outputRoot.Controls.Add(this.btnSave, 0, 5);
            this.outputRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputRoot.Location = new System.Drawing.Point(8, 8);
            this.outputRoot.Name = "outputRoot";
            this.outputRoot.RowCount = 7;
            this.outputRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.outputRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.outputRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.outputRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.outputRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.outputRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.outputRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outputRoot.Size = new System.Drawing.Size(396, 630);
            this.outputRoot.TabIndex = 0;
            // 
            // outputRowName
            // 
            this.outputRowName.AutoSize = true;
            this.outputRowName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.outputRowName.Controls.Add(this.lblName);
            this.outputRowName.Controls.Add(this.txtName);
            this.outputRowName.Location = new System.Drawing.Point(0, 0);
            this.outputRowName.Margin = new System.Windows.Forms.Padding(0);
            this.outputRowName.Name = "outputRowName";
            this.outputRowName.Size = new System.Drawing.Size(292, 23);
            this.outputRowName.TabIndex = 0;
            this.outputRowName.WrapContents = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(0, 6);
            this.lblName.Margin = new System.Windows.Forms.Padding(0, 6, 8, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Emoji name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(72, 3);
            this.txtName.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(220, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Emoji";
            this.txtName.TextChanged += new System.EventHandler(this.OnNameChanged);
            // 
            // chkAutoGrid
            // 
            this.chkAutoGrid.AutoSize = true;
            this.chkAutoGrid.Checked = true;
            this.chkAutoGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoGrid.Location = new System.Drawing.Point(0, 35);
            this.chkAutoGrid.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.chkAutoGrid.Name = "chkAutoGrid";
            this.chkAutoGrid.Size = new System.Drawing.Size(130, 17);
            this.chkAutoGrid.TabIndex = 1;
            this.chkAutoGrid.Text = "Auto grid (square root)";
            this.chkAutoGrid.CheckedChanged += new System.EventHandler(this.OnAutoGridChanged);
            // 
            // outputRowGrid
            // 
            this.outputRowGrid.AutoSize = true;
            this.outputRowGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.outputRowGrid.Controls.Add(this.lblCols);
            this.outputRowGrid.Controls.Add(this.numCols);
            this.outputRowGrid.Controls.Add(this.lblRows);
            this.outputRowGrid.Controls.Add(this.numRows);
            this.outputRowGrid.Location = new System.Drawing.Point(0, 56);
            this.outputRowGrid.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.outputRowGrid.Name = "outputRowGrid";
            this.outputRowGrid.Size = new System.Drawing.Size(203, 23);
            this.outputRowGrid.TabIndex = 2;
            this.outputRowGrid.WrapContents = false;
            // 
            // lblCols
            // 
            this.lblCols.AutoSize = true;
            this.lblCols.Location = new System.Drawing.Point(0, 6);
            this.lblCols.Margin = new System.Windows.Forms.Padding(0, 6, 4, 0);
            this.lblCols.Name = "lblCols";
            this.lblCols.Size = new System.Drawing.Size(30, 13);
            this.lblCols.TabIndex = 0;
            this.lblCols.Text = "Cols:";
            // 
            // numCols
            // 
            this.numCols.Enabled = false;
            this.numCols.Location = new System.Drawing.Point(34, 3);
            this.numCols.Margin = new System.Windows.Forms.Padding(0, 3, 16, 0);
            this.numCols.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCols.Name = "numCols";
            this.numCols.Size = new System.Drawing.Size(56, 20);
            this.numCols.TabIndex = 1;
            this.numCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numCols.ValueChanged += new System.EventHandler(this.OnGridChanged);
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(106, 6);
            this.lblRows.Margin = new System.Windows.Forms.Padding(0, 6, 4, 0);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(37, 13);
            this.lblRows.TabIndex = 2;
            this.lblRows.Text = "Rows:";
            // 
            // numRows
            // 
            this.numRows.Enabled = false;
            this.numRows.Location = new System.Drawing.Point(147, 3);
            this.numRows.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.numRows.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(56, 20);
            this.numRows.TabIndex = 3;
            this.numRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numRows.ValueChanged += new System.EventHandler(this.OnGridChanged);
            // 
            // chkShowGrid
            // 
            this.chkShowGrid.AutoSize = true;
            this.chkShowGrid.Location = new System.Drawing.Point(0, 91);
            this.chkShowGrid.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.chkShowGrid.Name = "chkShowGrid";
            this.chkShowGrid.Size = new System.Drawing.Size(137, 17);
            this.chkShowGrid.TabIndex = 3;
            this.chkShowGrid.Text = "Overlay grid on preview";
            this.chkShowGrid.CheckedChanged += new System.EventHandler(this.OnShowGridChanged);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFileName.Location = new System.Drawing.Point(0, 124);
            this.lblFileName.Margin = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(65, 15);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "Output: —";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(0, 151);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.btnSave.Size = new System.Drawing.Size(133, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Sprite Sheet…";
            this.btnSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 738);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1280, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.rootLayout);
            this.MinimumSize = new System.Drawing.Size(900, 580);
            this.Name = "Form1";
            this.Text = "VRC GIF to Emoji";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.rootLayout.ResumeLayout(false);
            this.rootLayout.PerformLayout();
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.centerSplit.Panel1.ResumeLayout(false);
            this.centerSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.centerSplit)).EndInit();
            this.centerSplit.ResumeLayout(false);
            this.toolsTabs.ResumeLayout(false);
            this.tabFrames.ResumeLayout(false);
            this.framesRoot.ResumeLayout(false);
            this.framesRoot.PerformLayout();
            this.framesRowButtons.ResumeLayout(false);
            this.framesRowButtons.PerformLayout();
            this.framesRowKeep.ResumeLayout(false);
            this.framesRowKeep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKeepEvery)).EndInit();
            this.framesRowTrim.ResumeLayout(false);
            this.framesRowTrim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTrimStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrimEnd)).EndInit();
            this.tabEffects.ResumeLayout(false);
            this.effectsRoot.ResumeLayout(false);
            this.effectsRoot.PerformLayout();
            this.effectsRowRotate.ResumeLayout(false);
            this.effectsRowRotate.PerformLayout();
            this.effectsRowFlip.ResumeLayout(false);
            this.effectsRowFlip.PerformLayout();
            this.tabSpeed.ResumeLayout(false);
            this.speedRoot.ResumeLayout(false);
            this.speedRoot.PerformLayout();
            this.speedRowFps.ResumeLayout(false);
            this.speedRowFps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkFps)).EndInit();
            this.tabOutput.ResumeLayout(false);
            this.outputRoot.ResumeLayout(false);
            this.outputRoot.PerformLayout();
            this.outputRowName.ResumeLayout(false);
            this.outputRowName.PerformLayout();
            this.outputRowGrid.ResumeLayout(false);
            this.outputRowGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
