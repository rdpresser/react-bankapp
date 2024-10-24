import { useEffect, useState } from 'react';

function Customer() {
    const [data, setData] = useState();

    useEffect(() => {
        populateData();
    }, []);

    const contents = data === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>City</th>
                    <th>Birth Date</th>
                    <th>Document</th>
                </tr>
            </thead>
            <tbody>
                {data.map(item =>
                    <tr key={item.id}>
                        <td>{item.name}</td>
                        <td>{item.city}</td>
                        <td>{item.dateOfBirth}</td>
                        <td>{item.identityDocument}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Customer List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateData() {
        const response = await fetch('/api/customer');
        const data = await response.json();
        setData(data);
    }
}

export default Customer;