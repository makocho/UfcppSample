using System;

namespace SoundLibrary.Pipe.Stereo
{
	/// <summary>
	/// �ڒ����s���N���X�B
	/// �f�[�^�̊Ԃ�⊮���āA�f�[�^����ς��邱�ƂŁA������ύX����B
	/// �Đ����Ԃ��ς���Ă��܂��B
	/// </summary>
	/// <remarks>
	/// ���`��Ԃɂ��A�b�v�T���v��/�_�E���T���v�����Ă��邾���Ȃ̂ŁA
	/// ��������ڎw���Ȃ�A�ʓr�A�A���`�G�C���A�X�t�B���^��������K�v������B
	/// </remarks>
	public class RateTransposer : Pipe
	{
		#region �萔

		const double DEFAULT_RATE = 1.0;

		#endregion
		#region �t�B�[���h

		// �p�����[�^
		double rate; // �ϊ����[�g�B������ rate �A�Đ����Ԃ� 1/rate �{�ɁB

		// ���݂̏��
		short prevL; // 1���O�̃f�[�^(L)���ꎞ�I�ɕۑ����Ă����B
		short prevR; // 1���O�̃f�[�^(R)���ꎞ�I�ɕۑ����Ă����B
		double delta; // Bresenham �A���S���Y���iDDA�j�I�ȓ�������邽�߂̏�ԕϐ��B

		#endregion
		#region ������

		/// <summary>
		/// �f�t�H���g�l�ŏ������B
		/// </summary>
		/// <param name="input">���̓L���[</param>
		/// <param name="output">�o�̓L���[</param>
		public RateTransposer(Queue input, Queue output)
			: this(input, output, DEFAULT_RATE)
		{
		}

		/// <summary>
		/// �p�����[�^�̐ݒ�B
		/// </summary>
		/// <param name="input">���̓L���[</param>
		/// <param name="output">�o�̓L���[</param>
		/// <param name="rate">�ϊ����[�g�B������ rate �{�A�Đ����Ԃ� 1/rate �{�ɁB</param>
		public RateTransposer(Queue input, Queue output, double rate)
			: base(input, output)
		{
			this.rate = rate;
			this.delta = rate / 2;
		}

		#endregion
		#region �p�����[�^�ݒ�

		/// <summary>
		/// �ϊ����[�g�B������ rate �A�Đ����Ԃ� 1/rate �{�ɁB
		/// </summary>
		public double Rate
		{
			get{return this.rate;}
			set
			{
				this.rate = value;
				this.delta = value / 2;
			}
		}

		#endregion
		#region ����

		public override void Process()
		{
			while(this.input.Count >= 2)
			{
				if(this.delta >= 0)
				{
					short l = Interpolate(this.delta, this.input[0], this.prevL);
					this.output.Enqueue(l);

					short r = Interpolate(this.delta, this.input[1], this.prevR);
					this.output.Enqueue(r);

					this.delta -= this.rate;
				}
				else
				{
					this.prevL = this.input[0];
					this.prevR = this.input[1];
					this.input.Dequeue(2);

					this.delta += 1;
				}
			}
		}

		#endregion
		#region �⏕�֐�(private)

		/// <summary>
		/// ���`��Ԋ֐��B
		/// </summary>
		/// <param name="delta">val1 �� val2 �������銄���i���������͖��������j</param>
		/// <param name="val1">�l1</param>
		/// <param name="val2">�l2</param>
		/// <returns></returns>
		static short Interpolate(double delta, short val1, short val2)
		{
			delta -= (int)delta;
			double val = val1 + delta * (val2 - val1);
			return (short)val;
		}

		#endregion
	}
}