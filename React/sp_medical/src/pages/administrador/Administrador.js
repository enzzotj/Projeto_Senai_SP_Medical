import { Component } from "react";
import './estilo.css'
// import Logo from '../img/logo1.png'

class Administrador extends Component {

    constructor(props) {
        super(props);
        this.state = {
            listaAdministrador: [],
            titulo: '',

        };
    };


    BuscarAdministrador = () => {
        console.log("Chamar Api")

        fetch('http://localhost:5000/api/Consultas')

            .then(resposta => resposta.json())

            .then(dados => this.setState({ listaAdministrador: dados }))

            .catch(erro => console.log(erro))
    }


    componentDidMount() {
        this.BuscarAdministrador()
    }

    render() {

        return (

            <div className="container_fundotab">

                <header>
                    <div class="container container_header">

                        {/* <img className="logo" src="img/logo1.png" alt="logo"> */}
                        {/* <Logo className="logo" alt="logo"/> */}
                        <div className ="container_final_header">
                        <h1>Administrador</h1>
                        {/* <input className ="img_sair" type ="image" src="img/SairBranco.png" alt="Sair"> */}
                        </div>
                    </div>
                </header>

                <main>
                    <div className="container_centralizar">
                    <section className="container_tab">
                        <table className="table">

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
                                    this.state.listaAdministrador.map((listaAdm) => {
                                        return (
                                            <tr key={listaAdm.idConsulta}>
                                                <td>{listaAdm.idConsulta}</td>
                                                <td>{listaAdm.nomePaciente}</td>
                                                <td>{listaAdm.nomeMedico}</td>
                                                <td>{listaAdm.Descricao}</td>
                                                <td>{listaAdm.situacao}</td>
                                                <td>{listaAdm.dataConsulta}</td>
                                            </tr>
                                        )
                                    }

                                    )
                                }

                            </tbody>

                        </table>

                    </section>
                    </div>
                </main>

            </div>
        )
    }

};

export default Administrador;