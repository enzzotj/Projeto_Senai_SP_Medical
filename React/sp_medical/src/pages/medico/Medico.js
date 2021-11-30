import { Component } from "react";
import './estilo.css'
import Logo from '../../../src/pages/img/logo1.png'

class Medico extends Component {

    constructor(props) {
        super(props);
        this.state = {
            listaMedico: [],
            titulo: '',

        };
    };


    BuscarMedico = () => {
        console.log("Chamar Api")

        fetch('http://localhost:5000/api/Consultas')

            .then(resposta => resposta.json())

            .then(dados => this.setState({ listaMedico: dados }))

            .catch(erro => console.log(erro))
    }


    componentDidMount() {
        this.BuscarMedico()
    }

    render() {

        return (

            <div className="container_fundotab">

                <header>
                    <div class="container container_header">

                        {/* <img className="logo" src={Logo} alt="logo"> */}
                        {/* <Logo className="logo" alt="logo"/> */}
                        <div className ="container_final_header">
                        <h1>Paciente</h1>
                        {/* <input className ="img_sair" type ="image" src="img/SairBranco.png" alt="Sair"> */}
                        </div>
                    </div>
                </header>

                <main>
                    <div className="container_centralizar">
                    <section className="container_tab">
                        <table className="">

                            <thead>
                                <tr>

                                    <th>Consulta</th>
                                    <th>Nome</th>
                                    <th>Descriçao</th>
                                    <th>Situaçao</th>
                                    <th>Data</th>

                                </tr>

                            </thead>

                            <tbody>

                                {
                                    this.state.listaMedico.map((listaMedico) => {
                                        return (
                                            <tr key={listaMedico.idConsulta}>
                                                <td>{listaMedico.idConsulta}</td>
                                                <td>{listaMedico.nomePaciente}</td>
                                                <td>{listaMedico.descricao}</td>
                                                <td>{listaMedico.situacao}</td>
                                                <td>{listaMedico.dataConsulta}</td>
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

export default Medico;