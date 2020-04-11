using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.musicPlayer.pattern.adapter
{
    class NAudioAdapter : IMyMediaPlayer
    {
        NAudio.Wave.DirectSoundOut output;

        public NAudioAdapter()
        {
            this.output = new NAudio.Wave.DirectSoundOut();  
        }

        public void play(string path)
        {
            NAudio.Wave.WaveStream a = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(path));
            NAudio.Wave.BlockAlignReductionStream stream = new NAudio.Wave.BlockAlignReductionStream(a);
            this.output.Init(stream);
            this.output.Play();
        }

        public void pause()
        {
            this.output.Pause();
        }

        public void stop()
        {
            this.output.Stop();
        }

        public void resume()
        {
            this.output.Play();
        }
    }
}
