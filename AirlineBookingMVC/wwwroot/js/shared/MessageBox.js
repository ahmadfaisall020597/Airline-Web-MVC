class MessageBox {
    static show(message){
        
        const dialog = $('#messageBox')        
        const body = $('#messageBody')
        
        body.html(message)
        dialog.modal('show')       
        
    }
}