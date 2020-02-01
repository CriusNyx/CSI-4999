public class DummyDamage {

    private ContactPoint contact { get; } //TODO: Set on projectile logic prior to destroying projectile

    public DummyDamage DummyDamage(ContactPoint contact) {
        this.contact = contact;
        return this;
    }


}