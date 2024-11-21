    
    let inp = document.getElementById("inp");
    let list = document.getElementById("list");

    function addItem() {
      let taskText = inp.value.trim();
      if (taskText) { 
        let newTask = document.createElement("li");
        newTask.innerHTML = taskText + " <button onclick=\"deleteItem(event)\">Delete Task</button>";
        list.append(newTask);
        inp.value = ""; 
      } else {
        alert("Please enter a task.");
      }
    }

    function deleteItem(event) {
      event.target.parentElement.remove();
      alert("Awesome! Keep the momentum!");
    }