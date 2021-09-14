

[SerializedField] 



Update(){
    dir.x = Input.GetButtonDown("Horizontal");
    dir.y = Input.GetButtonDown("Vertical");
    mouseL = Input.GetButtonDown("Mouse0");
    //TODO: implement double click
}   