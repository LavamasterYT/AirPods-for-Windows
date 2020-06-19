namespace ConfigutatorUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startStopServiceButton = new System.Windows.Forms.Button();
            this.openReadMe = new System.Windows.Forms.Button();
            this.addToStartup = new System.Windows.Forms.Button();
            this.deviceList = new System.Windows.Forms.ListBox();
            this.pairUSB = new System.Windows.Forms.Button();
            this.templateList = new System.Windows.Forms.ListBox();
            this.refreshDevices = new System.Windows.Forms.Button();
            this.refreshTemplates = new System.Windows.Forms.Button();
            this.addTemplate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.applySelectedToDevice = new System.Windows.Forms.Button();
            this.usingImage = new System.Windows.Forms.CheckBox();
            this.useDeviceName = new System.Windows.Forms.CheckBox();
            this.loop = new System.Windows.Forms.CheckBox();
            this.assetLbl = new System.Windows.Forms.Label();
            this.assetLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.defaultName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonText = new System.Windows.Forms.TextBox();
            this.windowBackground = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.windowForeground = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonBackground = new System.Windows.Forms.Panel();
            this.buttonForeground = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tint = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dummyName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.testUI = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.convert = new System.Windows.Forms.Button();
            this.saveTo = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.templateName = new System.Windows.Forms.TextBox();
            this.pairBT = new System.Windows.Forms.Button();
            this.removeDevice = new System.Windows.Forms.Button();
            this.removeTemplate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startStopServiceButton
            // 
            this.startStopServiceButton.Location = new System.Drawing.Point(13, 13);
            this.startStopServiceButton.Name = "startStopServiceButton";
            this.startStopServiceButton.Size = new System.Drawing.Size(116, 23);
            this.startStopServiceButton.TabIndex = 0;
            this.startStopServiceButton.Text = "Start/Stop Service";
            this.startStopServiceButton.UseVisualStyleBackColor = true;
            this.startStopServiceButton.Click += new System.EventHandler(this.startStopServiceButton_Click_1);
            // 
            // openReadMe
            // 
            this.openReadMe.Location = new System.Drawing.Point(135, 12);
            this.openReadMe.Name = "openReadMe";
            this.openReadMe.Size = new System.Drawing.Size(124, 23);
            this.openReadMe.TabIndex = 1;
            this.openReadMe.Text = "Open README.txt";
            this.openReadMe.UseVisualStyleBackColor = true;
            this.openReadMe.Click += new System.EventHandler(this.openReadMe_Click);
            // 
            // addToStartup
            // 
            this.addToStartup.Location = new System.Drawing.Point(265, 13);
            this.addToStartup.Name = "addToStartup";
            this.addToStartup.Size = new System.Drawing.Size(208, 23);
            this.addToStartup.TabIndex = 2;
            this.addToStartup.Text = "Add to/Remove from Startup Programs";
            this.addToStartup.UseVisualStyleBackColor = true;
            this.addToStartup.Click += new System.EventHandler(this.addToStartup_Click);
            // 
            // deviceList
            // 
            this.deviceList.FormattingEnabled = true;
            this.deviceList.Location = new System.Drawing.Point(13, 59);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(213, 251);
            this.deviceList.TabIndex = 3;
            // 
            // pairUSB
            // 
            this.pairUSB.Location = new System.Drawing.Point(479, 12);
            this.pairUSB.Name = "pairUSB";
            this.pairUSB.Size = new System.Drawing.Size(135, 23);
            this.pairUSB.TabIndex = 4;
            this.pairUSB.Text = "Pair USB Device";
            this.pairUSB.UseVisualStyleBackColor = true;
            this.pairUSB.Click += new System.EventHandler(this.pairUSB_Click);
            // 
            // templateList
            // 
            this.templateList.FormattingEnabled = true;
            this.templateList.Location = new System.Drawing.Point(232, 59);
            this.templateList.Name = "templateList";
            this.templateList.Size = new System.Drawing.Size(196, 251);
            this.templateList.TabIndex = 5;
            this.templateList.SelectedIndexChanged += new System.EventHandler(this.templateList_SelectedIndexChanged);
            // 
            // refreshDevices
            // 
            this.refreshDevices.Location = new System.Drawing.Point(12, 326);
            this.refreshDevices.Name = "refreshDevices";
            this.refreshDevices.Size = new System.Drawing.Size(110, 23);
            this.refreshDevices.TabIndex = 6;
            this.refreshDevices.Text = "Refresh Devices";
            this.refreshDevices.UseVisualStyleBackColor = true;
            this.refreshDevices.Click += new System.EventHandler(this.refreshDevices_Click);
            // 
            // refreshTemplates
            // 
            this.refreshTemplates.Location = new System.Drawing.Point(232, 326);
            this.refreshTemplates.Name = "refreshTemplates";
            this.refreshTemplates.Size = new System.Drawing.Size(196, 23);
            this.refreshTemplates.TabIndex = 7;
            this.refreshTemplates.Text = "Refresh";
            this.refreshTemplates.UseVisualStyleBackColor = true;
            this.refreshTemplates.Click += new System.EventHandler(this.refreshTemplates_Click);
            // 
            // addTemplate
            // 
            this.addTemplate.Location = new System.Drawing.Point(232, 355);
            this.addTemplate.Name = "addTemplate";
            this.addTemplate.Size = new System.Drawing.Size(42, 23);
            this.addTemplate.TabIndex = 8;
            this.addTemplate.Text = "Add";
            this.addTemplate.UseVisualStyleBackColor = true;
            this.addTemplate.Click += new System.EventHandler(this.addTemplate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Device List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Template List";
            // 
            // applySelectedToDevice
            // 
            this.applySelectedToDevice.Enabled = false;
            this.applySelectedToDevice.Location = new System.Drawing.Point(12, 355);
            this.applySelectedToDevice.Name = "applySelectedToDevice";
            this.applySelectedToDevice.Size = new System.Drawing.Size(214, 23);
            this.applySelectedToDevice.TabIndex = 11;
            this.applySelectedToDevice.Text = "Apply Selected Template to Device";
            this.applySelectedToDevice.UseVisualStyleBackColor = true;
            this.applySelectedToDevice.Click += new System.EventHandler(this.applySelectedToDevice_Click);
            // 
            // usingImage
            // 
            this.usingImage.AutoSize = true;
            this.usingImage.Location = new System.Drawing.Point(441, 81);
            this.usingImage.Name = "usingImage";
            this.usingImage.Size = new System.Drawing.Size(85, 17);
            this.usingImage.TabIndex = 12;
            this.usingImage.Text = "Using Image";
            this.usingImage.UseVisualStyleBackColor = true;
            // 
            // useDeviceName
            // 
            this.useDeviceName.AutoSize = true;
            this.useDeviceName.Checked = true;
            this.useDeviceName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useDeviceName.Location = new System.Drawing.Point(533, 81);
            this.useDeviceName.Name = "useDeviceName";
            this.useDeviceName.Size = new System.Drawing.Size(113, 17);
            this.useDeviceName.TabIndex = 13;
            this.useDeviceName.Text = "Use Device Name";
            this.useDeviceName.UseVisualStyleBackColor = true;
            // 
            // loop
            // 
            this.loop.AutoSize = true;
            this.loop.Checked = true;
            this.loop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loop.Location = new System.Drawing.Point(653, 81);
            this.loop.Name = "loop";
            this.loop.Size = new System.Drawing.Size(99, 17);
            this.loop.TabIndex = 14;
            this.loop.Text = "Loop Animation";
            this.loop.UseVisualStyleBackColor = true;
            // 
            // assetLbl
            // 
            this.assetLbl.AutoSize = true;
            this.assetLbl.Location = new System.Drawing.Point(441, 105);
            this.assetLbl.Name = "assetLbl";
            this.assetLbl.Size = new System.Drawing.Size(80, 13);
            this.assetLbl.TabIndex = 15;
            this.assetLbl.Text = "Asset Location:";
            // 
            // assetLocation
            // 
            this.assetLocation.Location = new System.Drawing.Point(527, 102);
            this.assetLocation.Name = "assetLocation";
            this.assetLocation.Size = new System.Drawing.Size(223, 20);
            this.assetLocation.TabIndex = 16;
            this.assetLocation.Text = "$docs$\\AirPodsUI\\Assets\\ag1.mp4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label3.Location = new System.Drawing.Point(442, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(309, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Check README for variables you can use on the asset location";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(440, 150);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(112, 13);
            this.nameLbl.TabIndex = 18;
            this.nameLbl.Text = "Default Device Name:";
            // 
            // defaultName
            // 
            this.defaultName.Location = new System.Drawing.Point(558, 147);
            this.defaultName.Name = "defaultName";
            this.defaultName.Size = new System.Drawing.Size(192, 20);
            this.defaultName.TabIndex = 19;
            this.defaultName.Text = "AirPods";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Button Text:";
            // 
            // buttonText
            // 
            this.buttonText.Location = new System.Drawing.Point(512, 174);
            this.buttonText.Name = "buttonText";
            this.buttonText.Size = new System.Drawing.Size(238, 20);
            this.buttonText.TabIndex = 21;
            // 
            // windowBackground
            // 
            this.windowBackground.BackColor = System.Drawing.Color.White;
            this.windowBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.windowBackground.Location = new System.Drawing.Point(557, 203);
            this.windowBackground.Name = "windowBackground";
            this.windowBackground.Size = new System.Drawing.Size(20, 20);
            this.windowBackground.TabIndex = 22;
            this.windowBackground.Click += new System.EventHandler(this.windowBackground_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Window Background:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(583, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Window Foreground:";
            // 
            // windowForeground
            // 
            this.windowForeground.BackColor = System.Drawing.Color.Black;
            this.windowForeground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.windowForeground.Location = new System.Drawing.Point(695, 203);
            this.windowForeground.Name = "windowForeground";
            this.windowForeground.Size = new System.Drawing.Size(20, 20);
            this.windowForeground.TabIndex = 23;
            this.windowForeground.Click += new System.EventHandler(this.windowForeground_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(449, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Button Background:";
            // 
            // buttonBackground
            // 
            this.buttonBackground.AllowDrop = true;
            this.buttonBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.buttonBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonBackground.Location = new System.Drawing.Point(557, 229);
            this.buttonBackground.Name = "buttonBackground";
            this.buttonBackground.Size = new System.Drawing.Size(20, 20);
            this.buttonBackground.TabIndex = 23;
            this.buttonBackground.Click += new System.EventHandler(this.buttonBackground_DoubleClick);
            // 
            // buttonForeground
            // 
            this.buttonForeground.BackColor = System.Drawing.Color.Black;
            this.buttonForeground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonForeground.Location = new System.Drawing.Point(695, 229);
            this.buttonForeground.Name = "buttonForeground";
            this.buttonForeground.Size = new System.Drawing.Size(20, 20);
            this.buttonForeground.TabIndex = 24;
            this.buttonForeground.Click += new System.EventHandler(this.buttonForeground_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(591, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Button Foreground:";
            // 
            // tint
            // 
            this.tint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.tint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tint.Location = new System.Drawing.Point(557, 255);
            this.tint.Name = "tint";
            this.tint.Size = new System.Drawing.Size(20, 20);
            this.tint.TabIndex = 24;
            this.tint.Click += new System.EventHandler(this.tint_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(522, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Tint:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dummyName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.testUI);
            this.groupBox1.Location = new System.Drawing.Point(441, 293);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 55);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test UI";
            // 
            // dummyName
            // 
            this.dummyName.Location = new System.Drawing.Point(123, 21);
            this.dummyName.Name = "dummyName";
            this.dummyName.Size = new System.Drawing.Size(100, 20);
            this.dummyName.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Dummy Device Name:";
            // 
            // testUI
            // 
            this.testUI.Location = new System.Drawing.Point(229, 19);
            this.testUI.Name = "testUI";
            this.testUI.Size = new System.Drawing.Size(75, 23);
            this.testUI.TabIndex = 0;
            this.testUI.Text = "Test UI";
            this.testUI.UseVisualStyleBackColor = true;
            this.testUI.Click += new System.EventHandler(this.testUI_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(441, 355);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(80, 23);
            this.save.TabIndex = 29;
            this.save.Text = "Save As...";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // convert
            // 
            this.convert.Location = new System.Drawing.Point(613, 355);
            this.convert.Name = "convert";
            this.convert.Size = new System.Drawing.Size(139, 23);
            this.convert.TabIndex = 30;
            this.convert.Text = "Open Old Template";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // saveTo
            // 
            this.saveTo.Location = new System.Drawing.Point(527, 355);
            this.saveTo.Name = "saveTo";
            this.saveTo.Size = new System.Drawing.Size(80, 23);
            this.saveTo.TabIndex = 31;
            this.saveTo.Text = "Save";
            this.saveTo.UseVisualStyleBackColor = true;
            this.saveTo.Click += new System.EventHandler(this.saveTo_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(434, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Template Name:";
            // 
            // templateName
            // 
            this.templateName.Location = new System.Drawing.Point(525, 55);
            this.templateName.Name = "templateName";
            this.templateName.Size = new System.Drawing.Size(223, 20);
            this.templateName.TabIndex = 33;
            // 
            // pairBT
            // 
            this.pairBT.Location = new System.Drawing.Point(620, 13);
            this.pairBT.Name = "pairBT";
            this.pairBT.Size = new System.Drawing.Size(130, 23);
            this.pairBT.TabIndex = 34;
            this.pairBT.Text = "Pair Bluetooth Device";
            this.pairBT.UseVisualStyleBackColor = true;
            this.pairBT.Click += new System.EventHandler(this.pairBT_Click);
            // 
            // removeDevice
            // 
            this.removeDevice.Location = new System.Drawing.Point(128, 326);
            this.removeDevice.Name = "removeDevice";
            this.removeDevice.Size = new System.Drawing.Size(98, 23);
            this.removeDevice.TabIndex = 35;
            this.removeDevice.Text = "Remove Device";
            this.removeDevice.UseVisualStyleBackColor = true;
            this.removeDevice.Click += new System.EventHandler(this.removeDevice_Click);
            // 
            // removeTemplate
            // 
            this.removeTemplate.Location = new System.Drawing.Point(280, 355);
            this.removeTemplate.Name = "removeTemplate";
            this.removeTemplate.Size = new System.Drawing.Size(148, 23);
            this.removeTemplate.TabIndex = 36;
            this.removeTemplate.Text = "Remove Selected Template";
            this.removeTemplate.UseVisualStyleBackColor = true;
            this.removeTemplate.Click += new System.EventHandler(this.removeTemplate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 403);
            this.Controls.Add(this.removeTemplate);
            this.Controls.Add(this.removeDevice);
            this.Controls.Add(this.pairBT);
            this.Controls.Add(this.templateName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.saveTo);
            this.Controls.Add(this.convert);
            this.Controls.Add(this.save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tint);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonForeground);
            this.Controls.Add(this.buttonBackground);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.windowForeground);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.windowBackground);
            this.Controls.Add(this.buttonText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.defaultName);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.assetLocation);
            this.Controls.Add(this.assetLbl);
            this.Controls.Add(this.loop);
            this.Controls.Add(this.useDeviceName);
            this.Controls.Add(this.usingImage);
            this.Controls.Add(this.applySelectedToDevice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addTemplate);
            this.Controls.Add(this.refreshTemplates);
            this.Controls.Add(this.refreshDevices);
            this.Controls.Add(this.templateList);
            this.Controls.Add(this.pairUSB);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.addToStartup);
            this.Controls.Add(this.openReadMe);
            this.Controls.Add(this.startStopServiceButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Configurator v0.4";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startStopServiceButton;
        private System.Windows.Forms.Button openReadMe;
        private System.Windows.Forms.Button addToStartup;
        private System.Windows.Forms.ListBox deviceList;
        private System.Windows.Forms.Button pairUSB;
        private System.Windows.Forms.ListBox templateList;
        private System.Windows.Forms.Button refreshDevices;
        private System.Windows.Forms.Button refreshTemplates;
        private System.Windows.Forms.Button addTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button applySelectedToDevice;
        private System.Windows.Forms.CheckBox usingImage;
        private System.Windows.Forms.CheckBox useDeviceName;
        private System.Windows.Forms.CheckBox loop;
        private System.Windows.Forms.Label assetLbl;
        private System.Windows.Forms.TextBox assetLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox defaultName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox buttonText;
        private System.Windows.Forms.Panel windowBackground;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel windowForeground;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel buttonBackground;
        private System.Windows.Forms.Panel buttonForeground;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel tint;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dummyName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button testUI;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button convert;
        private System.Windows.Forms.Button saveTo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox templateName;
        private System.Windows.Forms.Button pairBT;
        private System.Windows.Forms.Button removeDevice;
        private System.Windows.Forms.Button removeTemplate;
    }
}

