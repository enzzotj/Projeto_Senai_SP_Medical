import { Component } from "react";

class Administrador extends Component {

    constructor(props) {
        super(props);
        this.state = {
            listaAdministrador: [{Consulta : 1, Nome: "Enzzo", Medico: "Jaco", Descriçao: "Doente", Situaçao: "Andamento", Data: "11/11/2011"}, {Consulta : 2, Nome: "aaa", Medico: "bbb", Descriçao: "Sei la", Situaçao: "Finalizado", Data: "01/01/2021"}],
            titulo: ''
        };
    };


    BuscarAdministrador = () => {

        fetch('http://localhost:5000/api/Consultas')

        .then(resposta => resposta.json())

        .then(dados => this.setState({listaAdministrador : dados}))

        .catch(erro => console.log(erro))
    }


    componentDidMount() {
        this.BuscarAdministrador()
    }

    render() {

        return (

            <div>

                <main>

                    <section>

                        <h2>Lista para Administrador</h2>
                        <table>

                            <thead>
                                <tr>

                                    <th>Consulta</th>
                                    <th>Nome</th>
                                    <th>Medico</th>
                                    <th>Descriçao</th>
                                    <th>Situaçao</th>
                                    <th>Data</th>

                                </tr>

                            </thead>

                            <tbody>

                            {
                                    this.state.listaAdministrador.map( (listaAdm) => {
                                        return(
                                            <tr key={listaAdm.Consulta}>
                                               <td>{listaAdm.Consulta}</td> 
                                               <td>{listaAdm.Nome}</td> 
                                               <td>{listaAdm.Medico}</td> 
                                               <td>{listaAdm.Descriçao}</td> 
                                               <td>{listaAdm.Situaçao}</td> 
                                               <td>{listaAdm.Data}</td> 
                                            </tr>
                                        )
                                    }

                                    )
                                }

                            </tbody>

                        </table>

                    </section>

                </main>

            </div>
        )
    }

};

export default Administrador;