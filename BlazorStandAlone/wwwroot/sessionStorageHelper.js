window.sessionStorageHelper = {
    setItem: (key, value) => sessionStorage.setItem(key, JSON.stringify(value)),
    getItem: (key) => {
        const value = sessionStorage.getItem(key);
        return value ? JSON.parse(value) : null;
    },
    getItemAsString: (key) => sessionStorage.getItem(key),
    removeItem: (key) => sessionStorage.removeItem(key),
    clear: () => sessionStorage.clear()
}