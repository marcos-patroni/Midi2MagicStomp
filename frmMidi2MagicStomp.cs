namespace Midi2MagicStomp;
using Commons.Music.Midi;

public partial class frmMidi2MagicStomp : Form
{
    public frmMidi2MagicStomp()
    {
        InitializeComponent();
    }

    private void frmMidi2MagicStomp_Load(object sender, EventArgs e)
    {

        showMidiInputs();
    }
    private void showMidiInputs()
    {
        var access = MidiAccessManager.Default;
        foreach (var item in access.Inputs)
        {
            comboInput.Items.Add(item.Name);
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
        if (dados[0] < MidiEvent.Program && dados[0] > MidiEvent.Program + 15)
            return;
        lvW.AlteraPrograma(dados[1] + 1);
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var access = MidiAccessManager.Default;
        foreach (var item in access.Inputs)
        {
            var selectedCombo = (ComboBox)sender;
            if (selectedCombo.Text == item.Name)
            {
                listenMidiInput(access.OpenInputAsync(item.Id).Result);
                break;
            }
        }
    }
}
