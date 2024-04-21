document.addEventListener('DOMContentLoaded', function () {
    handleProfileImageUpload()
})

function handleProfileImageUpload() {
    try {

        let fileUploader = document.querySelector('#fileUploader')
        if (fileUploader != undefined) {
            fileUploader.addEventListner('change', function () {
                if (his.files.length > 0) {
                    this.form.submit()
                }
            })
        }

    }
    catch { }
}