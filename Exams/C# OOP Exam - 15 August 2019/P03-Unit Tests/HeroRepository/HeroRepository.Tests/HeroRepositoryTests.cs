using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository heroRepository;
    [SetUp]
    public void SetUp()
    {
        hero = new Hero("Pesho", 10);
        heroRepository = new HeroRepository();
    }
    [Test]
    public void HeroInitializesCorrectly()
    {
        Assert.AreEqual("Pesho", this.hero.Name);
        Assert.AreEqual(10, this.hero.Level);

    }
    [Test]
    public void HeroRepositoryInitializesCorrectly()
    {
        Assert.AreEqual(0, this.heroRepository.Heroes.Count);
    }
    [Test]
    public void CreateShouldThrowExceptionWhenNameNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.heroRepository.Create(null);
        }, "Hero is null");
    }
    [Test]
    public void CreateShouldThrowExceptionWhenNameAlreadyExists()
    {
        this.heroRepository.Create(this.hero);
        Assert.Throws<InvalidOperationException>(() =>
        {
            this.heroRepository.Create(this.hero);
        }, "Hero with name Pesho already exists");
    }

    [Test]
    public void CreateShouldAddProperly()
    {
        string expectedResult = "Successfully added hero Pesho with level 10";        
        string actualResult = this.heroRepository.Create(this.hero);
        Assert.AreEqual(1, this.heroRepository.Heroes.Count);
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("                ")]
    public void RemoveShouldThrowExceptionWhenNameNull(string name)
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.heroRepository.Remove(name);
        }, "Name cannot be null");
    }
    [Test]
    public void RemoveShouldReturnTrueWhenSuccessful()
    {
        this.heroRepository.Create(this.hero);
        bool actualResult = this.heroRepository.Remove("Pesho");
        bool expectedResult = true;
        Assert.AreEqual(expectedResult, actualResult);
        Assert.AreEqual(0, this.heroRepository.Heroes.Count);

    }
    [Test]
    public void RemoveShouldReturnFalseWhenNotSuccessful()
    {
        
        bool actualResult = this.heroRepository.Remove("Pesho");
        bool expectedResult = false;
        Assert.AreEqual(expectedResult, actualResult);
        Assert.AreEqual(0, this.heroRepository.Heroes.Count);

    }
    [Test]
    public void GetHeroWithHighestLevelWhenThereIsOneHero()
    {
        this.heroRepository.Create(this.hero);
        Hero actualHero = this.heroRepository.GetHeroWithHighestLevel();
        Assert.AreEqual(this.hero.Name, actualHero.Name);
        Assert.AreEqual(this.hero.Level, actualHero.Level);

    }
    [Test]
    public void GetHeroWithHighestLevelWhenThereAreTwoHeros()
    {
        Hero secondHero = new Hero("Ivan", 15);
        this.heroRepository.Create(this.hero);
        this.heroRepository.Create(secondHero);
        Hero actualHero = this.heroRepository.GetHeroWithHighestLevel();
        Assert.AreEqual(secondHero.Name, actualHero.Name);
        Assert.AreEqual(secondHero.Level, actualHero.Level);

    }
    [Test]
    public void GetHeroWithHighestLevelWhenThereAreNoHeros()
    {
        Assert.Throws<IndexOutOfRangeException>(() =>
        {

            Hero actualHero = this.heroRepository.GetHeroWithHighestLevel();
        });
       

    }
    [Test]
    public void GetHeroShouldReturnCorrectResult()
    {
        this.heroRepository.Create(this.hero);
        Hero actualHero = this.heroRepository.GetHero("Pesho");
        Assert.AreEqual(this.hero.Name, actualHero.Name);
        Assert.AreEqual(this.hero.Level, actualHero.Level);

    }
    [Test]
    public void GetHeroShouldReturnNullWhenNameDoesNotExist()
    {
        
        Hero actualHero = this.heroRepository.GetHero("Pesho");
        Assert.AreEqual(null, actualHero);
        

    }
}