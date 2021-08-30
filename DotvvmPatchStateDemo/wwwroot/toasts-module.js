export default context => new ToastsModule(context);

class ToastsModule {

    constructor(context) {
        this.context = context;

        this.connection = new signalR.HubConnectionBuilder().withUrl("/toasthub").build();
        this.connection.on("ShowToast", toast => this._onShowToast(toast));
        this.connection.start();

        dotvvm.patchState({ Title: 'Title set in JS module constructor' });
    }

    _onShowToast(toast) {
        console.log(dotvvm.state.Title);
        dotvvm.patchState({ Title: toast });
        console.log(dotvvm.state.Title);
    }

    $dispose() {
        this.connection.stop();
    }
}