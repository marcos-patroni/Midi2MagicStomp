namespace Midi2MagicStomp;
using Commons.Music.Midi;

public partial class frmMidi2MagicStomp : Form
{
    private dadosMS dataMS = new();
    private IMidiOutput outDevice = default!;
    Patch patch = default!;
    private byte conta = 0;
    public frmMidi2MagicStomp()
    {
        InitializeComponent();
    }

    private void frmMidi2MagicStomp_Load(object sender, EventArgs e)
    {
        showMidiInputs();
        showMidiOutputs();
    }
    private void showMidiInputs()
    {
        var access = MidiAccessManager.Default;
        foreach (var item in access.Inputs)
        {
            comboInput.Items.Add(item.Name);
            comboBox1.Items.Add(item.Name);
        }
    }
    private void showMidiOutputs()
    {
        var access = MidiAccessManager.Default;
        foreach (var item in access.Outputs)
        {
            comboOutput.Items.Add(item.Name);
        }
    }
    private void listenMidiInput(IMidiInput inDevice)
    {
        this.txtInfo.Text = "";
        try
        {
            ListViewWrapper lvW = new();
            inDevice.MessageReceived += (object? sender, MidiReceivedEventArgs e) => dadosEntrada(e.Data, lvW);
        }
        catch (Exception exc)
        {
            this.txtInfo.Text = exc.Message;
            inDevice.CloseAsync().Wait(1000);
        }

    }

    private void dadosEntrada(byte[] dados, ListViewWrapper lvW)
    {
        if (dados[0] < MidiEvent.Program || dados[0] > MidiEvent.Program + 15)
            return;
        lvW.AlteraPrograma(dados[1] + 1);
    }

    private void receiveData(IMidiInput inDevice)
    {

        this.txtInfo.Text = "";
        try
        {
            inDevice.MessageReceived += (object? sender, MidiReceivedEventArgs e) => dadosEntrada(e.Data);
        }
        catch (Exception exc)
        {
            this.txtInfo.Text = exc.Message;
            inDevice.CloseAsync().Wait(1000);
        }
    }
    private void dadosEntrada(byte[] dados)
    {

        if (dados[0] == MidiEvent.SysEx1)
        {
            if (dados.Length == 15)
            {
                conta++;
                if (conta > 98)
                    return;
                Task.Delay(100).Wait(100);
                outDevice.Send(new byte[] { MidiEvent.SysEx1, 67, 125, 80, 85, 66, 48, 1, conta, 247 }, 0, 10, 0);
            }


            if (dados.Length == 47)
            {
                patch = new Patch();
                patch.PatchName = dados;
            }

            if (dados.Length == 142)
            {
                patch.PatchData = dados;
                dataMS.Patches.Add(patch);
            }


        }
    }

    private void comboOutput_SelectedIndexChanged(object sender, EventArgs e)
    {
        var access = MidiAccessManager.Default;
        foreach (var item in access.Outputs)
        {
            var selectedCombo = (ComboBox)sender;
            if (selectedCombo.Text == item.Name)
            {
                if (outDevice == null)
                    outDevice = access.OpenOutputAsync(item.Id).Result;
                dataMS.Patches = new();
                selectedCombo.Enabled = false;
                comboInput.Enabled = false;
                outDevice.Send(new byte[] { MidiEvent.SysEx1, 67, 125, 80, 85, 66, 48, 1, 0, 247 }, 0, 10, 0);
                break;
            }
        }
    }

    private void txtInfo_TextChanged(object sender, EventArgs e)
    {

    }

    private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        var access = MidiAccessManager.Default;
        foreach (var item in access.Inputs)
        {
            var selectedCombo = (ComboBox)sender;
            if (selectedCombo.Text == item.Name)
            {
                receiveDataMidi(access.OpenInputAsync(item.Id).Result);
            }
        }
    }

    private void receiveDataMidi(IMidiInput inDevice)
    {

        this.txtInfo.Text = "";
        try
        {
            inDevice.MessageReceived += (object? sender, MidiReceivedEventArgs e) =>
            {
                if (e.Data[0] < MidiEvent.Program || e.Data[0] > MidiEvent.Program + 15)
                    return;
                var contaPatch = 0;

                foreach (var item in dataMS.Patches)
                {
                    if (contaPatch == e.Data[1] + 1)
                    {
                        outDevice.Send(new byte[] { MidiEvent.SysEx1, 67, 125, 48, 85, 66, 57, 57, 0, 0, 48, 3, 0, 77, 247 }, 0, 15, 0);
                        outDevice.Send(item.PatchName, 0, 47, 0);
                        outDevice.Send(item.PatchData, 0, 142, 0);
                        outDevice.Send(new byte[] { MidiEvent.SysEx1, 67, 125, 48, 85, 66, 57, 57, 0, 0, 48, 19, 0, 61, 247 }, 0, 15, 0);
                        break;
                    }
                    contaPatch++;

                }
            };
        }
        catch (Exception exc)
        {
            this.txtInfo.Text = exc.Message;
            inDevice.CloseAsync().Wait(1000);
        }
    }

    private void comboInput_SelectedIndexChanged(object sender, EventArgs e)
    {
        var access = MidiAccessManager.Default;
        foreach (var item in access.Inputs)
        {
            var selectedCombo = (ComboBox)sender;
            if (selectedCombo.Text == item.Name)
            {
                if (checkSoundEditor.Checked)
                    listenMidiInput(access.OpenInputAsync(item.Id).Result);
                else
                    receiveData(access.OpenInputAsync(item.Id).Result);
                break;
            }
        }
    }
}
