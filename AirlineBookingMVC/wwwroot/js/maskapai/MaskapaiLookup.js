class MaskapaiLookup {

    lookupDialog = $('#lkpMaskapaiDialog')
    baseUrl = '';
    token = '';
    
    constructor(baseUrl, token) {
        this.baseUrl = baseUrl;
        this.token = token;
        
    }

    findMaskapaiList(onSelected) {

        const that = this;

        fetch(this.baseUrl + '/api/maskapai/list', {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                't': this.token,
            }
            
        })
            .then(response => response.json())
            .then(data => {
                const body = $('#bodyMaskapaiLookup')
                body.empty();
                
                for (let i=0;i<data.length;i++) {
                    let d = data[i]
                    let str= '<tr>';
                    str += '<td><button type="button" class="btn btn-primary btn-select-maskapai" data-id="' + d.kodeMaskapai + '">Pilih</button></td>'
                    str += '<td>' + d.kodeMaskapai + '</td>'
                    str += '<td>' + d.namaMaskapai + '</td>'
                    str += '</tr>'
                    body.append(str)
                }

                $('.btn-select-maskapai').click(function (){
                    onSelected($(this).data('id'))
                    that.lookupDialog.modal('hide')

                });

                that.lookupDialog.modal('show');

            });
    }
}