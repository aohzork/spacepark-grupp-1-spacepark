/*(name) => {
    let parkedPersons = async () => {
        let response = await fetch(`URL ${name}`);
        return await response.json();
    }
    if (parkedPersons.name)
};*/

const IsParked = name => 
    new Promise((resolves, rejects) => {
        const api = `https://localhost:44350/api/v1.0/person/${name}`;
        const request = new XMLHttpRequest();
        request.open("GET", api, true);
        request.onload = () => 
        request.status === 200
            ? resolves(JSON.parse(request.response).results)
            : reject(Error(request.statusText));
        request.onerror = err => rejects(err);
        request.send();
    });
