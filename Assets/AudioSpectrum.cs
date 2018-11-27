using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSpectrum : MonoBehaviour {

	public Slider barPrefab;
	Slider [] bars;

	void Start()
	{
		bars = new Slider[16];
		for (int i = 0; i < bars.Length; ++i) {
			Slider bar = Instantiate (barPrefab, transform);
			bar.transform.localPosition = new Vector3 ((i - 8) * 20.0f, 0.0f, 0.0f);
			bars [i] = bar;
		}
	}

	void Update()
	{
		float[] spectrum = new float[256];

		AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

		for (int i = 0; i < bars.Length; ++i) {
			bars [i].value = spectrum [i];
		}
	}
}
