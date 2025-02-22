import bg from "../../assets/css/Backgrounds.module.css";
import styles from "../Hero/Hero.module.css";
import typography from "../../assets/css/Typography.module.css";
import Container from "../UI/Container";
import image from "../../assets/images/bitad-logo.svg";
import Loading from "../UI/Loading";

function ShortInfo({ title, description, isLoading = false }) {
  const shortMessage = (
    <>
      <h2>{title}</h2>
      <h4>{description}</h4>
    </>
  );

  return (
    <Container className={bg["hero-background"]}>
      <header className={`${styles.hero} ${typography["text-align--center"]}`}>
        {isLoading && <Loading fontSize="120px" />}
        {!isLoading && shortMessage}
        {!isLoading && <img src={image} alt="Logo Bitadu" />}
      </header>
    </Container>
  );
}

export default ShortInfo;
