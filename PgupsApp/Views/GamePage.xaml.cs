namespace MAUILearn;

public partial class GamePage : ContentPage
{
	private Button[] buttons;
	private int[] numbers = new int[16] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
	Random random = new Random();
	private int CorrectAnswer = 1;

    public GamePage()
	{
		InitializeComponent();
		buttons = new Button[16] { b00, b01, b02, b03, b10, b11, b12, b13, b20, b21, b22, b23, b30, b31, b32, b33 };
		RefreshNumbers();
	}
	
    private void Button_Clicked(object sender, EventArgs e)
    {
        HapticFeedback.Default.Perform(HapticFeedbackType.Click);
        CheckAnswer(sender as Button);
		
    }

	private void RefreshNumbers()
	{
		int[] tempNumbers = new int[16];
		for (int i = 0; i < buttons.Length; i++)
        {
			int rand = random.Next(0, 16);
			int tempNumber = numbers[rand];
			if (tempNumber == 0)
			{
				i--;
				continue;
			}
			tempNumbers[i] = tempNumber;
			buttons[i].Text = tempNumber.ToString();
			numbers[rand] = 0;
        }
		numbers = tempNumbers;

    }
	private void CheckAnswer(Button button)
	{
        if (button.Text == CorrectAnswer.ToString())
        {
			RefreshNumbers();
			CorrectAnswer++;
        }
        
	}
}