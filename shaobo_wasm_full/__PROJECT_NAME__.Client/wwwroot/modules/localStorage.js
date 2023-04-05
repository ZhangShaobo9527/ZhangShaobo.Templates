let get = function (key) {
    return JSON.parse(localStorage.getItem(key));
};

let contains = function (key) {
    return localStorage.getItem(key) !== null;
};

let set = function (key, value) {
    localStorage.setItem(key, value);
};

let watch = async function (dotnetWatcher) {
    window.addEventListener("storage", (e) => {
        dotnetWatcher.invokeMethodAsync("OnLocalStorageChangeAsync");
    });
};

export { get, contains, set, watch };