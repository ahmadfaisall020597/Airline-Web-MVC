class PesawatLookup {

    lookupDialog = $('#lkpPesawatDialog')
    baseUrl = '';
    token = '';
    constructor(baseUrl, token) {
        this.baseUrl = baseUrl;
        this.token = token;
        
    }

    findPesawatList(onSelected) {

        const that = this;
        fetch(this.baseUrl + '/api/pesawat/list', {

            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                't': this.token,
            }
            
        })
            .then(response => response.json())
            .then(data => {

                const body = $('#bodyPesawatLookup')
                body.empty();
                
                for (let i=0;i<data.length;i++) {
                    let d = data[i]
                    let str= '<tr>';
                    str += '<td><button type="button" class="btn btn-primary btn-select-pesawat" data-id="' + d.kodePenerbangan + '">Pilih</button></td>'
                    str += '<td>' + d.kodePenerbangan +  '</td>'
                    str += '<td>' + d.kodeJenisPesawat + '</td>'
                    str += '<td>' + d.kodeMaskapai + '</td>'
                    str += '</tr>'
                    body.append(str)
                }
                
                

                $('.btn-select-pesawat').click(function (){
                    onSelected($(this).data('id'))
                    that.lookupDialog.modal('hide')

                });

                that.lookupDialog.modal('show');

            });
    }
}