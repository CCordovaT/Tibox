(function (tibox) {
    tibox.video = {
        videoElement: document.getElementById("video"),
        play: function () {
            if (this.videoElement.paused) {
                this.videoElement.play();
            }
        },
        pause: function () {
            if (this.videoElement.played) {
                this.videoElement.pause();
            }
        },
        stop: function () {
            this.videoElement.currentTime = 0;
        }
    };
})(window.tibox = window.tibox || {});