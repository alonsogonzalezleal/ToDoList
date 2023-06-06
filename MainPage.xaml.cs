using System.Collections.ObjectModel;

namespace ToDoList;

public partial class MainPage : ContentPage
{
    private ObservableCollection<TaskItem> tasks = new ObservableCollection<TaskItem>();

    public MainPage()
    {
        InitializeComponent();
        taskListView.BindingContext = this;
    }

    public ObservableCollection<TaskItem> Tasks
    {
        get { return tasks; }
    }

    private void OnAddTaskClicked(object sender, EventArgs e)
    {
        string description = taskEntry.Text;
        if (!string.IsNullOrWhiteSpace(description))
        {
            TaskItem newTask = new TaskItem { Description = description };
            tasks.Add(newTask);
            taskEntry.Text = string.Empty;
        }
    }

    private void OnTaskCompletedChanged(object sender, CheckedChangedEventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        TaskItem task = (TaskItem)checkBox.BindingContext;
        task.IsCompleted = e.Value;
    }

    private void OnDeleteTaskClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        TaskItem task = (TaskItem)button.BindingContext;
        tasks.Remove(task);
    }
}